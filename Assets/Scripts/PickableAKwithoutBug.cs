using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// Script for managing pickable ak47
/// </summary>
public class PickableAK : MonoBehaviour
{
    int enteredRigidbodiesInTrigger = 0;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("inside trigger ak");
        enteredRigidbodiesInTrigger++; //so that it doesn't spam map in a case there is more things inside the trigger
        if (enteredRigidbodiesInTrigger > 1)
        {
            return;
        }
        Debug.Log(hitInfo.name);
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            if (player != null)
            {
                player.GetComponentInChildren<Weapon>().ReloadWeapon(WeaponsEnum.AK47);
            }
        }
        GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().SpawnNextWeapon();
        Destroy(gameObject);
    }
}