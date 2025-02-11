using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    SpaceShooterManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Wall"))
        {
           FindAnyObjectByType<SpaceShooterManager>().ReturnBullets(gameObject);
        }
        
    }
}
