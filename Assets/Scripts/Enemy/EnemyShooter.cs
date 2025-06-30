using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public int bulletDamage;
    public float bulletSpeed = 6f;
    public float shootCooldown = 2f;

    private float shootTimer;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        shootTimer = Random.Range(0f, shootCooldown); // offset so they don’t all shoot at once
    }

    void Update()
    {
        if (player == null) return;

        shootTimer += Time.deltaTime;

        if (shootTimer >= shootCooldown)
        {
            ShootAtPlayer();
            shootTimer = 0f;
        }
    }

    void ShootAtPlayer()
    {
        Vector2 direction = (player.position - firePoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDamage(bulletDamage);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;

        // Optional: rotate bullet to face movement
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
