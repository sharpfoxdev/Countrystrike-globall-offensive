using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Weapon with little ammo but spawns three bullets at once
/// </summary>
public class m58b : MonoBehaviour
{
    public Transform FirePoint1;
    public Transform FirePoint2;
    public Transform FirePoint3;

    public GameObject BulletPrefab;

    public int ammo = 4;
    public int currentAmmo;
    public readonly WeaponsEnum weapon = WeaponsEnum.M58B;

    /// <summary>
    /// Spawns three bullets in correct firepoints
    /// </summary>
    public void Shoot()
    {
        if(currentAmmo > 0)
        {
            Instantiate(BulletPrefab, FirePoint1.position, FirePoint1.rotation);
            Instantiate(BulletPrefab, FirePoint2.position, FirePoint2.rotation);
            Instantiate(BulletPrefab, FirePoint3.position, FirePoint3.rotation);
            currentAmmo--;
        }
    }
    /// <summary>
    /// Sets ammo to 0 in the beginning
    /// </summary>
    void Start()
    {
        currentAmmo = 0;
    }
    /// <summary>
    /// Called with player pics m58b bonus and adds ammo
    /// </summary>
    public void AddAmmo()
    {
        currentAmmo += ammo;
    }
}
