using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

/// <summary>
/// Manages players, their respawning and handles gameOver
/// </summary>
public class MultiplayerManager : MonoBehaviour
{
    [SerializeField]
    float respawnTime = 1;
    [SerializeField]
    List<GameObject> players = new List<GameObject>();
    [SerializeField]
    public GameObject MainMenu;
    public int PlayerCounter { get; set; }

    GameObject gameArea { get; set; }
    string[] controlSchemes { get; set; } = { "Player1", "Player2", "Player3", "Player4" };

    /// <summary>
    /// Handles initialisation of players and linking with control schemes on one keyboard
    /// </summary>
    /// <param name="players">List of players to initialise with already set skins</param>
    public void Init(List<GameObject> players)
    {
        this.players = players;
        PlayerCounter = players.Count;
        for (int i = 0; i < players.Count; i++)
        {
            PlayerInput.Instantiate(players[i], controlScheme: controlSchemes[i], pairWithDevice: Keyboard.current); //manually sets up control schemes
        }
    }

    /// <summary>
    /// Checks for game over every frame
    /// </summary>
    void Update()
    {
        //destroys the last player and brings us back to main menu
        if(PlayerCounter <= 1)
        {
            foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
            {
                Destroy(player);
            }
            MainMenu.SetActive(true);
        }
    }
    /// <summary>
    /// Manages dissapearing of player, after he gets hit
    /// </summary>
    /// <param name="player">Player to disappear</param>
    public void DisappearPlayer(GameObject player) //after getting shot
    {
        StartCoroutine(Respawn(player.gameObject));
    }
    IEnumerator Respawn(GameObject player)
    {
        PlayerInput pl = player.GetComponent<PlayerInput>(); //copying stuff to create players copy (beacuse the new input system is a garbage and it dissconects keyboard and bindings when player disappears)
        string ctrlscheme = pl.currentControlScheme;

        player.SetActive(false); //player disappears
        yield return new WaitForSeconds(respawnTime);//makes player disappear for a bit before respawning him

        RectTransform rt = gameArea.GetComponent<RectTransform>();

        if(player != null)//it kept throwing null ref error here, cuz sometimes I hit the player several times and it stopped already existing
        {
            player.transform.position = new Vector2(Random.Range(rt.rect.xMin, rt.rect.xMax), Random.Range(rt.rect.yMin, rt.rect.yMax)); //random place in game area
                                                                                                                                         //player.transform.position = new Vector2(Random.Range(-15f, 15f), Random.Range(-8f, 8f)); 
            player.GetComponent<PlayerMovement>().FaceRight(); //making him face right, otherwise he can sometimes move in the oposite direction than he is facing after respawning
            
            PlayerInput.Instantiate(player, controlScheme: ctrlscheme, pairWithDevice: Keyboard.current);
            Destroy(player); //creating copy and deleting disfunctional original
        }
        
    }
    void Start()
    {
        gameArea = GameObject.FindGameObjectWithTag("GameArea");
    }
}
