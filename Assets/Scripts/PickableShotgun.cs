using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script for managing pickable shotgun
/// </summary>
public class PickableShotgun : MonoBehaviour
{
    int enteredRigidbodiesInTrigger = 0;

    /// <summary>
    /// When somthing touches gun, it respawns and if it was player, it reloads its gun
    /// </summary>
    /// <param name="hitInfo"></param>
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        enteredRigidbodiesInTrigger++; //so that it doesn't spam map in a case there is more things inside the trigger
        if (enteredRigidbodiesInTrigger > 1)
        {
            return;
        }
        Player player = hitInfo.GetComponent<Player>(); //if it's player, that touched pickable gun, it reloads it's AK47
        if (player != null)
        {
            if (player != null)
            {
                player.GetComponentInChildren<Weapon>().ReloadWeapon(WeaponsEnum.M58B);
            }
        }
        GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().SpawnNextWeapon();
        Destroy(gameObject);
    }
}
