using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m58b : MonoBehaviour
{
    public Transform FirePoint1;
    public Transform FirePoint2;
    public Transform FirePoint3;

    public GameObject BulletPrefab;
    public void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint1.position, FirePoint1.rotation);
        Instantiate(BulletPrefab, FirePoint2.position, FirePoint2.rotation);
        Instantiate(BulletPrefab, FirePoint3.position, FirePoint3.rotation);

    }
}
