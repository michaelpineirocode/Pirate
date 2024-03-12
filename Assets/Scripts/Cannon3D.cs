using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon3D : MonoBehaviour
{
    public GameObject cannonballPrefab;
    public Transform shootPoint;
    public Transform target; // The target the cannon should aim at - assign this in the inspector or via code
    public float shootForce = 5f;
    public float shootRate = 2f; // Adjusted for demonstration purposes
    public float alignmentAngleThreshold = 10f; // The angle within which the cannon must be aligned to the target to fire
    private float nextShootTime = 0f;
 
    void Update()
    {
        if (Time.time >= nextShootTime && IsTargetAligned())
        {
            ShootCannonball();
            nextShootTime = Time.time + 1 / shootRate; // Adjusted for continuous shooting based on shootRate
        }
    }

    bool IsTargetAligned()
    {
        if (target != null)
        {
            Vector3 directionToTarget = (target.position - shootPoint.position).normalized;
            float angleToTarget = Vector3.Angle(shootPoint.forward, directionToTarget); // Use shootPoint.forward in 3D
            return angleToTarget <= alignmentAngleThreshold;
        }
        return false;
    }

    void ShootCannonball()
    {
        GameObject cannonball = Instantiate(cannonballPrefab, shootPoint.position, Quaternion.identity);

        Rigidbody rb = cannonball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 shootDirection = shootPoint.forward; // Assuming the forward direction of the shootPoint is the firing direction in 3D

            rb.AddForce(shootDirection * shootForce, ForceMode.Impulse);
        }

        // Note: Destroy based on time might not be appropriate for cannonballs if you want to simulate physics-based trajectories.
        // Consider using collision detection to destroy the cannonball on impact instead.
        Destroy(cannonball, 5f); // Lifetime of the cannonball, adjust as necessary
    }
}
