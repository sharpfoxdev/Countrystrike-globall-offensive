using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ak47 : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;
    private float cooldown = 2;
    private float cooldownTimer;
    bool isShooting;
    public void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);


    }
    IEnumerator ShootOneBullet(int depth, int currentDepth)
    {
        if(currentDepth >= depth)
        {
            
        }
        yield return new WaitForSeconds(1f);
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        StartCoroutine(ShootOneBullet(depth, currentDepth++));
    }
}
