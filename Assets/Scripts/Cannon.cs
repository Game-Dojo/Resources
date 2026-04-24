using System;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform ballSpawner;
    [SerializeField] private LayerMask enemiesLayer;
    
    [SerializeField] private GameObject bulletPrefab;
    private void FixedUpdate()
    {
       
        bool hit = Physics.Raycast(transform.position, transform.forward, 10f, enemiesLayer);
        if (!hit) return;
        Fire();
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, ballSpawner.position, Quaternion.identity);
        Rigidbody body = bullet.AddComponent<Rigidbody>();
        if (body) body.AddForce(transform.forward * 30f, ForceMode.Impulse);
    }
}
