using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Bullet Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public int bulletDamage = 1;
    public float bulletSpeed = 10f;
    public float bulletCooldown = 0.2f;
    private float bulletTimer;

    [Header("Missile Settings")]
    public GameObject missilePrefab;
    public int maxMissiles = 3;
    private int currentMissiles;
    public float missileCooldown = 1f;
    private float missileTimer;

    void Start()
    {
        currentMissiles = maxMissiles;
        bulletTimer = 0f;
        missileTimer = 0f;
    }

    void Update()
    {
        bulletTimer += Time.deltaTime;
        missileTimer += Time.deltaTime;

        // Shoot bullet with Left Click or Space
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && bulletTimer >= bulletCooldown)
        {
            FireBullet();
            bulletTimer = 0f;
        }

        // Shoot missile with Right Click or Left Shift
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(1)) && missileTimer >= missileCooldown && currentMissiles > 0)
        {
            FireMissile();
            missileTimer = 0f;
            currentMissiles--;
        }
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().SetDamage(bulletDamage);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.up * bulletSpeed;
    }

    void FireMissile()
    {
        GameObject missile = Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = missile.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.up * (bulletSpeed * 0.75f); // Slightly slower than bullets (adjust if needed)
    }

    // Called externally when picking up reload powerup or at round start
    public void ReloadMissiles()
    {
        currentMissiles = maxMissiles;
    }

    // Optional UI helper
    public int GetMissileCount()
    {
        return currentMissiles;
    }

    public void SetMissileCapacity(int count)
    {
        maxMissiles = count;
        currentMissiles = count;
    }
    public void SetDamage(int bulletDamage, int missileCount)
    {
        this.bulletDamage = bulletDamage;
        this.maxMissiles = missileCount;
    }
}
