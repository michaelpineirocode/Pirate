using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{
    public float forwardForce = 0.01f;
    public ForceMode2D forceMode = ForceMode2D.Force;
    public Rigidbody2D rb;
    public Transform sail;
    public Transform body;
    public PlayerController playerController;
    private float sail_deployment = 1;
    public Vector2 windForceDirection; // Force direction and magnitude


    public EnvironmentIntegrator env;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void updateEnvProperties() {
        windForceDirection = env.windForceDirection;
    }

    // Update is called once per frame
    void Update()
    {
        updateEnvProperties();
        if (playerController != null) {
            sail_deployment = playerController.sail_deployment;
        }
        addForceToSail();
        addDragForces();
        addConstantForwardForce();
    }

    void addDragForces() {
        //D = 1/2*fluid density*velocity^2*Area*drag coefficient.
        int area = 6;
        int fluid_density = 1;
        float drag_coefficient = 0.6f;
        float velocity = rb.velocity.magnitude;
        float drag = 0.5f * fluid_density * (float)Mathf.Pow(velocity, 2) * area * drag_coefficient;
        
        Vector2 velocityDirection = rb.velocity.normalized;

       rb.AddForce(-velocityDirection * drag);

    }

    void addForceToSail() {
        if (rb != null) {
            // Convert the angle from degrees to radians since Mathf.Sin expects radians
            float angleInRadians = sail.eulerAngles.z * Mathf.Deg2Rad;
            // Calculate the sine of the angle
            float sineOfAngle = Mathf.Abs(Mathf.Cos(angleInRadians));

            // Multiply the forceDirection by the sine of the angle
            Vector2 modifiedForceDirection = windForceDirection * sineOfAngle * sail_deployment;

            // Apply the force (example: applying it every frame while 'Update' runs)
            rb.AddForce(modifiedForceDirection, ForceMode2D.Force);
        } else {
            Debug.LogError("Rigidbody component missing from this GameObject.");
        }
    }

    void addConstantForwardForce() {
        float angleInRadians = (body.eulerAngles.z + 90) * Mathf.Deg2Rad;
        Vector2 forward = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
        rb.AddForce(forward * forwardForce, ForceMode2D.Force);
    }

}
