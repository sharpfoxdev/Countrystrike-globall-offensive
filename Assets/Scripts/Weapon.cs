using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class Weapon : MonoBehaviour
{
    public GameObject AK47;
    public GameObject Glock;
    public GameObject M58B;
    List<GameObject> weapons = new List<GameObject>();
    GameObject currentWeapon;
    int weaponIndex = 0 ;
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

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            switch (currentWeapon.name)
            {
                case "ak47":
                    currentWeapon.GetComponent<ak47>().Shoot();
                    break;
                case "glock":
                    currentWeapon.GetComponent<glock>().Shoot();
                    break;
                case "m58b":
                    currentWeapon.GetComponent<m58b>().Shoot();
                    break;
                default:
                    break;
            }
            //Glock.GetComponent<glock>().Shoot();
            //M58B.GetComponent<m58b>().Shoot();
        }
    }
    public void OnChangeWeapon(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            ChangeWeapon();
        }
    }
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
    public void ReloadWeapon(string weapon)
    {
        while(currentWeapon.name != weapon) //change to the weapon we picked, otherwise it gives null ref error
        {
            ChangeWeapon();
        }
        switch (weapon)
        {

            case "ak47":
                currentWeapon.GetComponent<ak47>().AddAmmo();
                break;
            case "m58b":
                currentWeapon.GetComponent<m58b>().AddAmmo();
                break;
            default:
                break;
        }
    }
}
