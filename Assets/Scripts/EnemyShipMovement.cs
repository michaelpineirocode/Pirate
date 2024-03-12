using UnityEngine;

public class EnemyShipMovement : MonoBehaviour
{
    public float speed = 5.0f; // Enemy ship's speed
    public float turnSpeed = 100.0f; // Speed at which the enemy ship turns to face the player
    public float detectionRange = 50.0f; // Range within which the enemy ship starts following the player

    private Rigidbody rb; // Reference to this ship's Rigidbody
    private Transform playerTransform; // Reference to the player's transform

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Find the player by tag
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= detectionRange)
        {
            // Calculate the direction to the player
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;

            // Optionally, turn to face the player smoothly
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);

            // Move towards the player
            rb.velocity = -transform.right * speed;
        }
        else
        {
            // Stop moving when the player is out of range
            rb.velocity = Vector3.zero;
        }
    }

        void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // Set the color of the Gizmos
        Gizmos.DrawWireSphere(transform.position, detectionRange); // Draw a wire sphere representing the detection range
    }
}
