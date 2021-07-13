using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            Shoot();
        }
    }
    public void OnChangeWeapon(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            ChangeWeapon();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
    void ChangeWeapon()
    {

    }
}
