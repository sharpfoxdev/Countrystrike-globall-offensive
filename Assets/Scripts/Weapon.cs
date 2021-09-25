using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using Mirror;

/// <summary>
/// Class handling shooting, changing guns and reloading, passes information further to exact guns
/// </summary>
public class Weapon : NetworkBehaviour
{
    public GameObject AK47;
    public GameObject Glock;
    public GameObject M58B;
    public bool isNetworked = false; //set to true in a case this script is run in networked scenario
    List<GameObject> weapons = new List<GameObject>();
    GameObject currentWeapon;

    int weaponIndex = 0; //keeps info of which weapon we are currently holding, used in non networking game
    int weaponWantedIndex = 0; //this changes first, in networking game
    [SyncVar(hook = nameof(OnWeaponChanged_Network))]
    int weaponSyncedIndex = 0; //then this changes after communication with server

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
    /// Update used only in networked scenario, because we use there different input system
    /// </summary>
    void Update()
    {
        if (isNetworked && isLocalPlayer)
        {
            TryWeaponChangeNetworked();
            TryWeaponShootNetworked();
            
        }
    }
    /// <summary>
    /// Checks for button pressed for weapon change, if button is pressed, then it contacts server
    /// </summary>
    void TryWeaponChangeNetworked()
    {
        if (Input.GetKeyDown(KeyCode.M))//weapon change
        {
            if (weaponWantedIndex >= weapons.Count - 1)
            {
                weaponWantedIndex = 0;
            }
            else
            {
                weaponWantedIndex++;
            }
            CmdChangeWeapon(weaponWantedIndex);//contacts server from this player instance only, because we are in isLocalPlayer check
        }
    }
    /// <summary>
    /// Run on the server, contacts all the clients to update players current weapon via hook
    /// </summary>
    /// <param name="newWeaponIndex">Index of weapon that we want to switch to</param>
    [Command]
    public void CmdChangeWeapon(int newWeaponIndex)
    {
        weaponSyncedIndex = newWeaponIndex; //this triggers hook
    }
    /// <summary>
    /// Called when weaponSyncedIndex gets updated from server via hook
    /// </summary>
    void OnWeaponChanged_Network(int oldIndex, int newIndex)
    {
        currentWeapon.SetActive(false);
        currentWeapon = weapons[newIndex];
        currentWeapon.SetActive(true);
    }
    /// <summary>
    /// Checks for button pressed for weapon shooting, if button is pressed, then it contacts server
    /// </summary>
    void TryWeaponShootNetworked()
    {
        if (Input.GetKeyDown(KeyCode.N))//weapon shooting
        {
            switch (currentWeapon.GetComponent<Gun>().Weapon)
            {
                case WeaponsEnum.AK47:
                    currentWeapon.GetComponent<AK47>().ShootNetwork();
                    break;
                case WeaponsEnum.Glock:
                    currentWeapon.GetComponent<glock>().ShootNetwork();
                    break;
                case WeaponsEnum.M58B:
                    currentWeapon.GetComponent<m58b>().ShootNetwork();
                    break;
                default:
                    break;
            }
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
