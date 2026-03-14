using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public float projectileSpeed = 7f;

    private float nextFireTime;

    void Update()
    {
        if (projectilePrefab == null || fireRate <= 0f)
            return;

        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;

            Transform spawnPoint = firePoint != null ? firePoint : transform;
            GameObject bullet = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.left * projectileSpeed;
            }
        }
    }
}