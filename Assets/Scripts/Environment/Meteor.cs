using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 30;
    public Vector2 direction = Vector2.right; // set from spawner

    void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>()?.TakeDamage(damage);
        }
        else if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>()?.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
