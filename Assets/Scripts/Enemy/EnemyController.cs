using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotationSpeed = 200f;
    private Transform target;
    private Transform t;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
        t = GetComponent<Transform>();
    }

    void Update()
    {
        if (target == null) return;

        // Move toward player
        Vector2 direction = (target.position - transform.position).normalized;
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);

        // Face the Player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (target.position == transform.position)
        {
            Vector2 new_direction = (target.position - transform.position - Vector3.one).normalized;
            transform.position += (Vector3)(new_direction * moveSpeed * Time.deltaTime);
        }

        if (t.position.x < -10)
        {
            Vector3 temp = t.position;
            temp.x = -10;
            t.position = temp;
        }
        else if (t.position.x > 10)
        {
            Vector3 temp = t.position;
            temp.x = 10;
            t.position = temp;
        }
        if (t.position.y < -6)
        {
            Vector3 temp = t.position;
            temp.y = -6;
            t.position = temp;
        }
        else if (t.position.y > 6)
        {
            Vector3 temp = t.position;
            temp.y = 6;
            t.position = temp;
        }
    }
}
