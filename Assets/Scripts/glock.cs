using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    void Awake()
    {
        Weapon = WeaponsEnum.Glock;
    } 
}
