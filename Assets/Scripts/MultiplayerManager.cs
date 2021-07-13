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

    // Start is called before the first frame update
    void Start()
    {
        var p1 = PlayerInput.Instantiate(playerPrefab1, controlScheme: "Player1", pairWithDevice: Keyboard.current);
        var p2 = PlayerInput.Instantiate(playerPrefab2, controlScheme: "Player2", pairWithDevice: Keyboard.current);
        var p3 = PlayerInput.Instantiate(playerPrefab3, controlScheme: "Player3", pairWithDevice: Keyboard.current);
        var p4 = PlayerInput.Instantiate(playerPrefab4, controlScheme: "Player4", pairWithDevice: Keyboard.current);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
