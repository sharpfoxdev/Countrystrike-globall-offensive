using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class MultiplayerManager : MonoBehaviour
{
    public float respawnTime = 1;
    //public int numberOfPlayers = 4;
    private string[] controlSchemes = { "Player1", "Player2", "Player3", "Player4" };
    public List<GameObject> players = new List<GameObject>();
    public GameObject MainMenu;
    public int PlayerCounter;
    //private List<GameObject> players = new List<GameObject>(){ playerPrefab1, playerPrefab2 };

    // Start is called before the first frame update
    public void Init()
    {
        PlayerCounter = players.Count;
        for (int i = 0; i < players.Count; i++)
        {
            PlayerInput.Instantiate(players[i], controlScheme: controlSchemes[i], pairWithDevice: Keyboard.current);
        }
    }
    void Update()
    {
        if(PlayerCounter <= 1)
        {
            foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
            {
                Destroy(player);
            }
            MainMenu.SetActive(true);
        }
    }
    public void DisappearPlayer(GameObject player)
    {
        StartCoroutine(Respawn(player.gameObject));
    }
    IEnumerator Respawn(GameObject player)
    {
        PlayerInput pl = player.GetComponent<PlayerInput>(); //copying stuff to create players copy (beacuse the new input system is a garbage and it dissconects keyboard and bindings when player disappears)
        string ctrlscheme = pl.currentControlScheme;
        Debug.Log(ctrlscheme);

        player.SetActive(false); //player disappears

        yield return new WaitForSeconds(respawnTime);//makes player disappear for a bit before respawning him

        GameObject gameArea = GameObject.FindGameObjectWithTag("GameArea");
        RectTransform rt = gameArea.GetComponent<RectTransform>();
        Debug.Log(rt.transform.position);
        Debug.Log(rt.rect.xMin);
        Debug.Log(rt.rect.yMin);
        Debug.Log(rt.rect.yMax);
        if(player != null)//it kept throwing null ref error here, cuz sometimes I hit the player several times and it stopped already existing
        {
            player.transform.position = new Vector2(Random.Range(rt.rect.xMin, rt.rect.xMax), Random.Range(rt.rect.yMin, rt.rect.yMax)); //random place in game area
                                                                                                                                         //player.transform.position = new Vector2(Random.Range(-15f, 15f), Random.Range(-8f, 8f)); 
            player.GetComponent<PlayerMovement>().FaceRight(); //making him face right, otherwise he can sometimes move in the oposite direction than he is facing after respawning
            
            PlayerInput.Instantiate(player, controlScheme: ctrlscheme, pairWithDevice: Keyboard.current);
            Destroy(player); //creating copy and deleting disfunctional original
        }
        
    }
}
