using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float rotationSpeed = 100.0f;
    public Transform sail;
    public Transform boat;

    // Update is called once per frame
    void Update()
    {
        // Check for the "A" key
        if (Input.GetKey(KeyCode.S))
        {
            // Rotate the object counterclockwise
            sail.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }

        // Check for the "D" key
        if (Input.GetKey(KeyCode.W))
        {
            // Rotate the object clockwise
            sail.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }

         if (Input.GetKey(KeyCode.A))
        {
            // Rotate the object counterclockwise
            boat.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }

         if (Input.GetKey(KeyCode.D))
        {
            // Rotate the object counterclockwise
            boat.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
    }
}
