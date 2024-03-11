using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipAI : MonoBehaviour
{
    public Transform playerShip;
    public Transform boat; // The transform component that represents the ship's body, similar to the player controller setup
    public float rotationSpeed = 2f; // How quickly the enemy ship rotates towards the player
    public float movementSpeed = 5f; // The forward speed of the ship

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RotateTowardsPlayer();
    }

    void FixedUpdate()
    {
        MoveForward();
    }

    void RotateTowardsPlayer()
    {
        if (playerShip != null)
        {
            Vector2 directionToPlayer = playerShip.position - boat.position;
            float targetAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg - 90;
            float angleStep = rotationSpeed * Time.deltaTime;
            float angle = Mathf.MoveTowardsAngle(boat.eulerAngles.z, targetAngle, angleStep);
            boat.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    void MoveForward()
    {
        // Movement is forward based on the boat's orientation
        rb.velocity = boat.up * movementSpeed;
    }
}
