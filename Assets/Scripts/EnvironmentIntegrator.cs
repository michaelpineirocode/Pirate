using System.Collections;
using UnityEngine;

public class EnvironmentIntegrator : MonoBehaviour
{
    public Vector2 windForceDirection = new Vector2(0, 10);
    public Vector2 waveSpawnDistance = new Vector2(0, -10);
    public float waveVelocityForce = 10.0f;
    public Transform player;
    public GameObject waveObject;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitRandomTimeCoroutine());
    }

    void instantiateWaves() {
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, windForceDirection);
        transform.rotation = rotation;
        Vector2 velocityForce = windForceDirection * waveVelocityForce;
        Vector2 location = new Vector2(player.position.x - waveSpawnDistance.x, player.position.y - waveSpawnDistance.y);
        
        // Instantiate the wave object and get a reference to the new instance
        GameObject waveInstance = Instantiate(waveObject, location, rotation);

        // Apply the force to the Rigidbody2D of the instantiated object, not the prefab
        Rigidbody2D rb = waveInstance.GetComponent<Rigidbody2D>();
        if (rb != null) {
            rb.AddForce(velocityForce, ForceMode2D.Force);
        } else {
            Debug.LogError("Rigidbody2D component missing from wave object prefab.");
        }
    }

    IEnumerator WaitRandomTimeCoroutine()
    {
        while (true) // Infinite loop to continuously wait and instantiate
        {
            // Generate a random time to wait
            float randomTime = Random.Range(1f, 5f); // Wait between 1 and 5 seconds

            Debug.Log($"Waiting for {randomTime} seconds...");
            yield return new WaitForSeconds(randomTime); // Wait for the random amount of time

            instantiateWaves(); // Instantiate waves after waiting

            Debug.Log("Wait is over. Executing next actions...");
        }
    }
}
