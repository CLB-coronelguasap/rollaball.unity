using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Drag your ball player here
    public Vector3 offset = new Vector3(0, 5, -10); // Adjust for height and distance
    public float smoothness = 5f;

    void LateUpdate()
    {
        // Calculate the desired position based on the ball's position + a fixed offset
        Vector3 targetPosition = player.position + offset;
        
        // Smoothly move the camera to that position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime);

        // Optional: Keep the camera looking at the ball
        transform.LookAt(player.position);
    }
}
