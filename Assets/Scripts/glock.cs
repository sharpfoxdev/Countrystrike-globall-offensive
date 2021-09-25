using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
//using UnityEngine.XR.WSA.Input;

/// <summary>
/// Basic weapon with infinity ammo and slow bullets
/// </summary>
public class glock : Gun
{
    public Transform FirePoint;

    /// <summary>
    /// Created bullet, it uses it's basic speed
    /// </summary>
    public override void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
    /// <summary>
    /// Created bullet, it uses it's basic speed, network version
    /// </summary>
    public override void ShootNetwork()
    {
        GameObject newBullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        NetworkServer.Spawn(newBullet);

    }

    void Awake()
    {
        Weapon = WeaponsEnum.Glock;
    } 
}
