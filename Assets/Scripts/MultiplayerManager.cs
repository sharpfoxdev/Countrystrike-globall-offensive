using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MultiplayerManager : MonoBehaviour
{
    public GameObject playerPrefab1;
    public GameObject playerPrefab2;
    public GameObject playerPrefab3;
    public GameObject playerPrefab4;
    public float respawnTime = 1;
    public int numberOfPlayers = 4;
    private string[] controlSchemes = { "Player1", "Player2", "Player3", "Player4" };
    //private List<GameObject> players = new List<GameObject>(){ playerPrefab1, playerPrefab2 };

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberOfPlayers; i++)
        {
            PlayerInput.Instantiate(playerPrefab1, controlScheme: controlSchemes[i], pairWithDevice: Keyboard.current);
        }
        /*var p1 = PlayerInput.Instantiate(playerPrefab1, controlScheme: "Player1", pairWithDevice: Keyboard.current);
        var p2 = PlayerInput.Instantiate(playerPrefab2, controlScheme: "Player2", pairWithDevice: Keyboard.current);
        var p3 = PlayerInput.Instantiate(playerPrefab3, controlScheme: "Player3", pairWithDevice: Keyboard.current);
        var p4 = PlayerInput.Instantiate(playerPrefab4, controlScheme: "Player4", pairWithDevice: Keyboard.current);*/

    }

    // Update is called once per frame
    void Update()
    {
        
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

        player.transform.position = new Vector2(Random.Range(-15f, 15f), Random.Range(-8f, 8f)); //random place in map
        player.GetComponent<PlayerMovement>().FaceRight(); //making him face right, otherwise he can sometimes move in the oposite direction than he is facing after respawning

        PlayerInput.Instantiate(player, controlScheme: ctrlscheme, pairWithDevice: Keyboard.current);
        Destroy(player); //creating copy and deleting disfunctional original
    }
}
