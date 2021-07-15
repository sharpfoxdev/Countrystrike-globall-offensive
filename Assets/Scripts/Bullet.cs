﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    //public int SpawnDelay = 1;
    //public GameObject playerManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name);
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.GetHit();
            GameObject playerManager = GameObject.Find("PlayerManager");
            playerManager.GetComponent<MultiplayerManager>().DisappearPlayer(player.gameObject);
        }
        Destroy(gameObject);
    }
}