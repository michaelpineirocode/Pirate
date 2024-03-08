using System.Collections;
using UnityEngine;

public class EnvironmentIntegrator : MonoBehaviour
{
    public Vector2 windForceDirection = new Vector2(0, 10);
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
        Instantiate(waveObject, player.position, rotation);
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
