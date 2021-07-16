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
        float speedBefore = BulletPrefab.GetComponent<Bullet>().speed;
        BulletPrefab.GetComponent<Bullet>().speed = 45f; // this is changing the prefab!!!
        Debug.Log(BulletPrefab.GetComponent<Bullet>().speed);
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        BulletPrefab.GetComponent<Bullet>().speed = speedBefore;

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
