using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Assign this in the inspector with the player's Transform
    public Vector3 offset; // You can adjust this in the inspector to set how far back the camera sits

    void LateUpdate()
    {
        if (player != null)
        {
            // Update the camera's position to follow the player, but keep its own rotation
            transform.position = player.position + offset;
        }
    }
}
