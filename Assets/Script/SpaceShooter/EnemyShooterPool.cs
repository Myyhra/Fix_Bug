using UnityEngine;
using UnityEngine.Pool;

public class EnemyShooterPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public ObjectPool<GameObject> bulletPool;
    public bool collectionCheck = false;
    public int defaultCapacityBullets = 1;
    public int maxBullets = 3;
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
