using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    public GameObject cannonballPrefab;
    public Transform shootPoint;
    public float shootForce = 5f;
    public float shootRate = 5f;
    public float shootRange = 1f;
    private float nextShootTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextShootTime) {
            ShootCannonball();
            nextShootTime = Time.time + shootRate;
        }
    }

    void ShootCannonball() {
        GameObject cannonball = Instantiate(cannonballPrefab, shootPoint.position, Quaternion.identity);

        Rigidbody2D rb = cannonball.GetComponent<Rigidbody2D>();
        if (rb != null) {
            rb.gravityScale = 0;

            Vector2 shootDirection = shootPoint.right;

            rb.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
        }

        Destroy(cannonball, shootRange);

        
    }
}
