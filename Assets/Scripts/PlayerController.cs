using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float rotationSpeed = 100.0f;
    public Transform sail;
    public Transform boat;
    public Transform camera;
    public float sail_deployment;
    public float sail_deployment_speed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            // Rotate the object counterclockwise
            sail.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
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

        if (Input.GetKey(KeyCode.W) && sail_deployment < 1)
        {
            // Rotate the object counterclockwise
            sail_deployment = sail_deployment + sail_deployment_speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S) && sail_deployment > 0)
        {
            // Rotate the object counterclockwise
            sail_deployment = sail_deployment - sail_deployment_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Rotate the object counterclockwise
            camera.Rotate(0, 0, 100.0f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Rotate the object counterclockwise
            camera.Rotate(0, 0, -100.0f * Time.deltaTime);
        }

        // Snaps the camera
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Rotate the object counterclockwise
            Quaternion q = new Quaternion();
            q.Set(0, 0, 0, 0);
            camera.rotation = q;
        }

         if (Input.GetKey(KeyCode.DownArrow))
        {
            // Rotate the object counterclockwise
            Quaternion q = new Quaternion();
            q.Set(0, 0, 180, 0);
            camera.rotation = q;
        }

    }
}
