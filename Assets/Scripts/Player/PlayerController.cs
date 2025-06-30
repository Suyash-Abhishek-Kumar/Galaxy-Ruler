using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float thrustForce = 5f;       // Forward/backward thrust force
    public float rotationSpeed = 200f;   // Degrees per second

    private Rigidbody2D rb;
    private Transform t;
    private float moveInput;
    private float rotateInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        t = GetComponent<Transform>();
    }

    void Update()
    {
        // Get inputs
        moveInput = Input.GetAxisRaw("Vertical");   // W/S
        rotateInput = -Input.GetAxisRaw("Horizontal"); // A/D → Unity rotates clockwise with negative z
    }

    void FixedUpdate()
    {
        // Apply forward/backward thrust (along local up)
        rb.AddForce(transform.up * moveInput * thrustForce, ForceMode2D.Force);

        // Apply rotation (Z axis)
        rb.MoveRotation(rb.rotation + rotateInput * rotationSpeed * Time.fixedDeltaTime);

        if (t.position.x < -9)
        {
            Vector3 temp = t.position;
            temp.x = -9;
            t.position = temp;
        }
        else if(t.position.x > 9)
        {
            Vector3 temp = t.position;
            temp.x = 9;
            t.position = temp;
        }
        if(t.position.y < -5)
        {
            Vector3 temp = t.position;
            temp.y = -5;
            t.position = temp;
        }
        else if (t.position.y > 5)
        {
            Vector3 temp = t.position;
            temp.y = 5;
            t.position = temp;
        }
    }

    // Optional: Set dynamic thrust/rotation values
    public void SetThrust(float thrust)
    {
        thrustForce = thrust;
    }

    public void SetRotationSpeed(float rotSpeed)
    {
        rotationSpeed = rotSpeed;
    }
    public void SetMovement(float thrustForce, float rotationSpeed)
    {
        this.thrustForce = thrustForce;
        this.rotationSpeed = rotationSpeed;
    }

}
