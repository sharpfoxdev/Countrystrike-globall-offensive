using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

/// <summary>
/// Class handling shooting, changing guns and reloading, passes information further to exact guns
/// </summary>
public class Weapon : MonoBehaviour
{
    public GameObject AK47;
    public GameObject Glock;
    public GameObject M58B;
    List<GameObject> weapons = new List<GameObject>();
    GameObject currentWeapon;
    int weaponIndex = 0; //keeps info of which weapon we are currently holding

    /// <summary>
    /// Sets up list of guns and sets glock as first gun to hold
    /// </summary>
    void Start()
    {
        weapons.Add(Glock);
        weapons.Add(AK47);
        weapons.Add(M58B);
        foreach(GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
        currentWeapon = weapons[weaponIndex];
        currentWeapon.SetActive(true);
    }
    /// <summary>
    /// Called, when shooting button is pressed
    /// </summary>
    /// <param name="context"></param>
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            switch (currentWeapon.GetComponent<Gun>().Weapon)
            {
                case WeaponsEnum.AK47:
                    currentWeapon.GetComponent<AK47>().Shoot();
                    break;
                case WeaponsEnum.Glock:
                    currentWeapon.GetComponent<glock>().Shoot();
                    break;
                case WeaponsEnum.M58B:
                    currentWeapon.GetComponent<m58b>().Shoot();
                    break;
                default:
                    break;
            }
        }
    }
    /// <summary>
    /// Called when button for changing weapon is pressed
    /// </summary>
    /// <param name="context"></param>
    public void OnChangeWeapon(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            ChangeWeapon();
        }
    }
    /// <summary>
    /// Iterates to the next weapon, that is in holster
    /// </summary>
    void ChangeWeapon()
    {
        currentWeapon.SetActive(false);
        if(weaponIndex >= weapons.Count - 1){
            weaponIndex = 0;
        }
        else
        {
            weaponIndex++;
        }
        currentWeapon = weapons[weaponIndex];
        currentWeapon.SetActive(true);
    }

    /// <summary>
    /// Changes current weapon to the picked one and adds ammo to it
    /// </summary>
    /// <param name="weapon"></param>
    public void ReloadWeapon(WeaponsEnum weapon)
    {
        //here used to be while loop, but it oftentimes got infinitelly looped and made my unity crash, so I changed it to for loop, which just results in error on the switch, when something goes wrong
        for(int i = 0; i < weapons.Count; i++) //change to the weapon we picked, otherwise it gives null ref error
        {
            ChangeWeapon();
            if(currentWeapon.GetComponent<Gun>().Weapon == weapon)
            {
                break;
            }
        }
        switch (weapon)
        {
            case WeaponsEnum.AK47:
                currentWeapon.GetComponent<AK47>().AddAmmo();
                break;
            case WeaponsEnum.M58B:
                currentWeapon.GetComponent<m58b>().AddAmmo();
                break;
            default:
                break;
        }
    }
}
