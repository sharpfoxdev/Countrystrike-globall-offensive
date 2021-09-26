using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

/// <summary>
/// Weapon with little ammo but spawns three bullets at once
/// </summary>
public class m58b : Gun
{
    public Transform FirePoint1;
    public Transform FirePoint2;
    public Transform FirePoint3;

    public int ammo = 4;
    public int currentAmmo;

    /// <summary>
    /// Spawns three bullets in correct firepoints
    /// </summary>
    public override void Shoot()
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
    /// Spawns three bullets in correct firepoints, network version
    /// </summary>
    [Command]
    public override void ShootNetwork()
    {
        if (currentAmmo > 0)
        {
            GameObject newBullet1 = Instantiate(BulletPrefab, FirePoint1.position, FirePoint1.rotation);
            GameObject newBullet2 = Instantiate(BulletPrefab, FirePoint2.position, FirePoint2.rotation);
            GameObject newBullet3 = Instantiate(BulletPrefab, FirePoint3.position, FirePoint3.rotation);
            NetworkServer.Spawn(newBullet1);
            NetworkServer.Spawn(newBullet2);
            NetworkServer.Spawn(newBullet3);

            currentAmmo--;
        }
    }
    /// <summary>
    /// Sets ammo to 0 in the beginning
    /// </summary>
    void Awake()
    {
        currentAmmo = 0;
        Weapon = WeaponsEnum.M58B;
    }
    /// <summary>
    /// Called with player pics m58b bonus and adds ammo
    /// </summary>
    public void AddAmmo()
    {
        Debug.Log("Called Add Ammo");
        Debug.Log(currentAmmo);
        Debug.Log(ammo);
        currentAmmo += ammo;
        Debug.Log(currentAmmo);
    }
}
