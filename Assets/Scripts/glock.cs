using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glock : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;
    public void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
