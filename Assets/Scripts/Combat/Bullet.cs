using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage = 1;
    public float lifeTime = 2f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    public void SetDamage(int dmg)
    {
        damage = dmg;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Deal damage to the enemy
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        else { Debug.Log("? Detected"); }
    }
}
