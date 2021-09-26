using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

/// <summary>
/// Small amount of ammo but speedy bullets
/// </summary>
public class AK47 : Gun
{
    public Transform FirePoint;
    public int MaxAmmo = 6;
    int currentAmmo;
    float bulletSpeed = 45f;

    /// <summary>
    /// Spawns bullet and makes it move in the correct direction
    /// </summary>
    public override void Shoot()
    {
        if(currentAmmo > 0)
        {
            GameObject newBullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
            newBullet.GetComponent<Bullet>().speed = bulletSpeed;
            currentAmmo--;
        }
    }
    /// <summary>
    /// Spawns bullet and makes it move in the correct direction, network version
    /// </summary>
    [Command]
    public override void ShootNetwork()
    {
        if (currentAmmo > 0)
        {
            GameObject newBullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
            newBullet.GetComponent<Bullet>().speed = bulletSpeed;
            NetworkServer.Spawn(newBullet);
            currentAmmo--;
        }
    }

    /// <summary>
    /// Called at start, to set amount off ammunition of AK47 to 0
    /// </summary>
    void Awake()
    {
        currentAmmo = 0;
        Weapon = WeaponsEnum.AK47;
    }

    /// <summary>
    /// Adds ammo when AK47 is picked on map
    /// </summary>
    public void AddAmmo()
    {
        currentAmmo += MaxAmmo;
    }
}
