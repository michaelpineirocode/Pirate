using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannonballPrefab;
    public Transform shootPoint;
    public Transform target; // The target the cannon should aim at - assign this in the inspector or via code
    public float shootForce = 5f;
    public float shootRate = 5f;
    public float shootRange = 1f;
    public float alignmentAngleThreshold = 10f; // The angle within which the cannon must be aligned to the target to fire
    private float nextShootTime = 0f;

    void Update()
    {
        if (Time.time >= nextShootTime && IsTargetAligned())
        {
            ShootCannonball();
            nextShootTime = Time.time + shootRate;
        }
    }

    bool IsTargetAligned()
    {
        if (target != null)
        {
            Vector2 directionToTarget = (target.position - shootPoint.position).normalized;
            float angleToTarget = Vector2.Angle(shootPoint.right, directionToTarget);
            return angleToTarget <= alignmentAngleThreshold;
        }
        return false;
    }

    void ShootCannonball()
    {
        GameObject cannonball = Instantiate(cannonballPrefab, shootPoint.position, Quaternion.identity);

        Rigidbody2D rb = cannonball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0;

            Vector2 shootDirection = shootPoint.right; // Assuming the right direction of the shootPoint is the forward firing direction

            rb.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
        }

        Destroy(cannonball, shootRange); // Adjust or remove based on your needs
    }
}
