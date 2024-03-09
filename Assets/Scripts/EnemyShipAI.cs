using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipAI : MonoBehaviour
{
    public Transform playerShip;
    public float detectionRange = 50f;
    public float attackRange = 30f;
    public float rotationSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        // Calculate distance to player
        float distanceToPlayer = Vector2.Distance(transform.position, playerShip.position);

        if (distanceToPlayer <= detectionRange) {
            RotateTowardsPlayer();
        }
    }

    void RotateTowardsPlayer() {
        // Determine direction to the player
        Vector2 directionToPlayer = playerShip.position - transform.position;
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg - 180f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
    }
}
