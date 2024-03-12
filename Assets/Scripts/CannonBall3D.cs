using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall3D : MonoBehaviour
{
    // Optional: Tag of the target for more specific collision detection
    public string targetTag = "Ship";

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the specific tag, if you're using tags
        if (collision.gameObject.CompareTag(targetTag))
        {
            Destroy(gameObject); // Destroy the cannonball
        }
    }
}
