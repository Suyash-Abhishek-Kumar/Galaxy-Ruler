using UnityEngine;

public class BlackHolePrefab : MonoBehaviour
{
    public float pullStrength = 3f;
    public float radius = 10f;

    void FixedUpdate()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radius);
        Debug.Log($"[BlackHole] Found {objects.Length} objects in radius");

        foreach (var obj in objects)
        {
            if (obj.gameObject == gameObject) continue; // ignore self

            Rigidbody2D rb = obj.attachedRigidbody;
            if (rb != null)
            {
                Vector2 direction = (transform.position - rb.transform.position).normalized;
                rb.AddForce(direction * pullStrength);
                Debug.Log($"[BlackHole] Pulling: {obj.name}");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
