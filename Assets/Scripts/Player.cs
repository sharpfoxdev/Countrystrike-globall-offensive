using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.XR.WSA.Input;

public class Player : MonoBehaviour
{
    public int Lives = 5;
    public int SpawnDelay = 2;
    public string PlayerName;
    public int PlayerNumber;

    public void GetHit()
    {
        Lives--;
        if(Lives <= 0)
        {
            GameObject.Find("PlayerManager").GetComponent<MultiplayerManager>().PlayerCounter--;
            Destroy(gameObject);
        }

    }

    void Start()
    {

    }

}
