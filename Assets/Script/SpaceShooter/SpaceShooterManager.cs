using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Pool;

public class SpaceShooterManager : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    public ObjectPool<GameObject> bulletPool;
    public bool collectionCheck = false;
    public int defaultCapacityBullets = 3;
    public int maxBullets = 6;
    // public Transform BulletSpawnHere;
    
    void Start()
    {
        bulletPool = new ObjectPool<GameObject>
        (    InstantiateBullet,
            SpawnBullet,
            DespawnBullet,
            DestroyBullet,
            collectionCheck,
            defaultCapacityBullets,
            maxBullets

        );
    }

    private GameObject InstantiateBullet()
    {
        return Instantiate(bulletPrefab);

    }

    void SpawnBullet(GameObject bullet)
    {
        bullet.SetActive(true);
    }
    private void DespawnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }

    void DestroyBullet(GameObject bullet)
    {
        Destroy(bullet);
    }

    
    public void ReturnBullets(GameObject bullet)
    {
        bulletPool.Release(bullet);
    }
   
}
