using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PickableAK : MonoBehaviour
{
    int enteredRigidbodiesInTrigger = 0;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        enteredRigidbodiesInTrigger++; //so that it doesn't spam map in a case there is more things inside the trigger
        if (enteredRigidbodiesInTrigger > 1)
        {
            return;
        }
        Debug.Log(hitInfo.name);
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.GetComponentInChildren<Weapon>().ReloadWeapon("ak47");
        }
        GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().SpawnNextWeapon();
        Destroy(gameObject);
    }
}
