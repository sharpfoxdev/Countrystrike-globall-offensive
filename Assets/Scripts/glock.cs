using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic weapon with infinity ammo and slow bullets
/// </summary>
public class glock : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;
    public readonly WeaponsEnum weapon = WeaponsEnum.Glock;

    /// <summary>
    /// Created bullet, it uses it's basic speed
    /// </summary>
    public void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
