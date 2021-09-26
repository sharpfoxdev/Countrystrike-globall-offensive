using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that is used to hold information on the type of weapon
/// This was before done directly by scripts attached to weapons, 
/// but I had to move them up the hierarchy to the root of player prefab, 
/// so they could spawn bullets on network
/// </summary>
public class WeaponTypeNetwork : MonoBehaviour
{
    [SerializeField]
    public WeaponsEnum weaponType;
    //seems that I sadly cannot attach structs as scripts to the objects
    //because they don't inherit from monobehaviour, so here goes class
}
