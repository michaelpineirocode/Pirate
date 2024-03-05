using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{

    public Vector2 forceDirection = new Vector2(0, 10); // Force direction and magnitude
    public ForceMode2D forceMode = ForceMode2D.Force;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody component attached to this GameObject
        if (rb != null)
        {
            rb.AddForce(forceDirection, forceMode); // Apply the force
        }
        else
        {
            Debug.LogError("Rigidbody component missing from this GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
