using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.XR.WSA.Input;

/// <summary>
/// Class for player
/// </summary>
public class Player : MonoBehaviour
{
    public int Lives = 5;
    public int SpawnDelay = 2; //not used currently
    public string PlayerName;
    public int PlayerNumber;
    public int AmountOfBulletsInCollider = 0; //fixing bug that when player is hit by multiple bullets at once, he respawns also several times
    private GameObject multiplayerManager;

    /// <summary>
    /// Manages health and death after being shot (running out of lives)
    /// </summary>
    public void GetHit()
    {
        Lives--;
        AmountOfBulletsInCollider++;
        if(Lives <= 0) //totally dies and not respawns again
        {
            multiplayerManager.GetComponent<MultiplayerManager>().PlayerCounter--; //decreases counter of total amount of players on the map
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// Gets multiplayer manager for notifying it in a case of death
    /// </summary>
    void Start()
    {
        multiplayerManager = GameObject.Find("PlayerManager");
    }
}
