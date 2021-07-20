using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pickableAK;
    public GameObject pickableShotgun;
    public GameObject gameArea;
    RectTransform rt;
    List<GameObject> pickableWeapons = new List<GameObject>();
    static Random random = new Random();

    // Start is called before the first frame update
    void Start()
    {
        rt = gameArea.GetComponent<RectTransform>();
        pickableWeapons.Add(pickableAK);
        pickableWeapons.Add(pickableShotgun);
        int index = Random.Range(0, pickableWeapons.Count);
        GameObject weaponToSpawn = pickableWeapons[index];
        weaponToSpawn.transform.position = new Vector2(Random.Range(rt.rect.xMin, rt.rect.xMax), Random.Range(rt.rect.yMin, rt.rect.yMax));
        Instantiate(weaponToSpawn);
    }
    public void SpawnNextWeapon()
    {
        int index = Random.Range(0, pickableWeapons.Count);
        GameObject weaponToSpawn = pickableWeapons[index];
        weaponToSpawn.transform.position = new Vector2(Random.Range(rt.rect.xMin, rt.rect.xMax), Random.Range(rt.rect.yMin, rt.rect.yMax));
        Instantiate(weaponToSpawn);
    }
}
