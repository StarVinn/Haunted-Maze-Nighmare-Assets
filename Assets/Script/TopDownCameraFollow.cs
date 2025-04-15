using UnityEngine;

public class TopDownCameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player
    public Vector3 offset; // Offset from the player
    public float smoothSpeed = 1f; // Smooth speed factor

    void LateUpdate()
    {
        // Calculate desired position
        Vector3 desiredPosition = player.position + offset;

        // Smoothly interpolate to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update camera position
        transform.position = smoothedPosition;

        // Optional: Keep the camera looking down at the player
        transform.LookAt(player.position);
    }
}