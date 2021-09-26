using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Telepathy;

/// <summary>
/// Spawns weapons randomly in a game area
/// </summary>
public class Spawner : NetworkBehaviour
{
    public GameObject pickableAK;
    public GameObject pickableShotgun;
    public GameObject gameArea;
    [SerializeField]
    bool isNetworked = false;
    RectTransform rt;
    List<GameObject> pickableWeapons = new List<GameObject>();

    /// <summary>
    /// Gets info about game area and spawns first weapon
    /// </summary>
    void Start()
    {
        if (isNetworked)//we dont want this thing to be called on networked version, we have OnStartServer for that
        {
            return;
        }
        rt = gameArea.GetComponent<RectTransform>();
        pickableWeapons.Add(pickableAK);
        pickableWeapons.Add(pickableShotgun);
        SpawnNextWeapon();
    }
    public override void OnStartServer()
    {
        rt = gameArea.GetComponent<RectTransform>();
        pickableWeapons.Add(pickableAK);
        pickableWeapons.Add(pickableShotgun);
        SpawnNextWeaponNetworked();
    }

    /// <summary>
    /// Spawns another weapon, after the previous one was picked
    /// </summary>
    public void SpawnNextWeapon()
    {
        int index = Random.Range(0, pickableWeapons.Count); //selects random weapon and spawns it on random position within gameArea
        GameObject weaponToSpawn = pickableWeapons[index];
        weaponToSpawn.transform.position = new Vector2(Random.Range(rt.rect.xMin, rt.rect.xMax), Random.Range(rt.rect.yMin, rt.rect.yMax));
        Instantiate(weaponToSpawn);
    }

    /// <summary>
    /// Spawns another weapon, after the previous one was picked
    /// Networked version
    /// Doesnt need to be a command, because we use this on Spawner object,
    /// whose net is has checkbox server only ticked in, so this gets run only on server
    /// </summary>
    public void SpawnNextWeaponNetworked()
    {
        int index = Random.Range(0, pickableWeapons.Count); //selects random weapon and spawns it on random position within gameArea
        GameObject weaponToSpawn = pickableWeapons[index];
        weaponToSpawn.transform.position = new Vector2(Random.Range(rt.rect.xMin, rt.rect.xMax), Random.Range(rt.rect.yMin, rt.rect.yMax));
        GameObject newWeapon = Instantiate(weaponToSpawn);
        NetworkServer.Spawn(newWeapon);
    }
}
