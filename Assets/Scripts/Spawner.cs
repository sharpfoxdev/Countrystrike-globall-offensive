using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns weapons randomly in a game area
/// </summary>
public class Spawner : MonoBehaviour
{
    public GameObject pickableAK;
    public GameObject pickableShotgun;
    public GameObject gameArea;
    RectTransform rt;
    List<GameObject> pickableWeapons = new List<GameObject>();

    /// <summary>
    /// Gets info about game area and spawns first weapon
    /// </summary>
    void Start()
    {
        rt = gameArea.GetComponent<RectTransform>();
        pickableWeapons.Add(pickableAK);
        pickableWeapons.Add(pickableShotgun);
        SpawnNextWeapon();
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
}
