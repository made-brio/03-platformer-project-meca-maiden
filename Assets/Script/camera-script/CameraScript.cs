using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;            // Reference to the player GameObject
    public Vector2 minBounds;          // Minimum X and Y the camera can go
    public Vector2 maxBounds;          // Maximum X and Y the camera can go
    public float smoothSpeed = 0.125f; // Smoothness of the camera follow
    public Vector3 offset;             // Offset from player to camera 

    private void LateUpdate()
    {
        if (player == null) return;

        // Target position with offset
        Vector3 desiredPosition = player.position + offset;

        // Clamp the camera to stay within background bounds
        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        float clampedY = transform.position.y;
        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        // Smooth follow
        transform.position = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);
    }
}
