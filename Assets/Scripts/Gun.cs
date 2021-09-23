using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract class for inheritation of other guns (ak47, shotgun)
/// </summary>
public abstract class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public WeaponsEnum Weapon; //for easier access to find out, what weapon I am holding, so it is in the base class

    /// <summary>
    /// All weapons shoot, thus this is an abstract class
    /// </summary>
    public abstract void Shoot();
}
