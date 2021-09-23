using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script for bullet instance
/// </summary>
public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public Rigidbody2D rb;
    //public int SpawnDelay = 1;

    /// <summary>
    /// Sets up rigidbody of bullet
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(speed);
        rb.velocity = transform.right * speed;
    }

    /// <summary>
    /// Manages hitting things with bullet
    /// </summary>
    /// <param name="hitInfo">Information what bullet hit</param>
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name);
        Player player = hitInfo.GetComponent<Player>(); //try to guess if what I hit was a player
        if (player != null) //if it was player then he gets hit
        {
            player.GetHit();
            if (player != null && player.GetComponent<Player>().AmountOfBulletsInCollider == 1) //if the player is not dead, then make him disappear for a few seconds
            {
                GameObject playerManager = GameObject.FindGameObjectWithTag("PlayerManager");
                playerManager.GetComponent<MultiplayerManager>().DisappearPlayer(player.gameObject);
            }    
        }
        Destroy(gameObject);
    }
}
