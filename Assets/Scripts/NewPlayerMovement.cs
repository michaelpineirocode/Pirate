using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public float acceleration = 5.0f;
    public float maxSpeed = 20.0f;
    public float maxReverseSpeed = -100.0f;
    private float currentSpeed = 0.0f;

    public float turnSpeed = 100.0f; // Speed at which the boat turns

    private Rigidbody rb; // Reference to the boat's Rigidbody component for physics-based movement

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the boat
    }

    void Update()
    {
        // Forward movement
        if (Input.GetKey(KeyCode.W)) {
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
        } else if (Input.GetKey(KeyCode.S)) {
            currentSpeed -= acceleration * Time.deltaTime;
            currentSpeed = Mathf.Max(currentSpeed, maxReverseSpeed);
        }

        rb.velocity = -transform.right * currentSpeed;

        // Turning
        float turnInput = Input.GetAxis("Horizontal"); // Get horizontal input for turning
        transform.Rotate(0, turnInput * turnSpeed * Time.deltaTime, 0);
    }

}
