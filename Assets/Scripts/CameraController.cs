using UnityEngine;

public class BallCamera : MonoBehaviour
{
    public Transform ball;
    public float height = 5f;
    public float distance = 5f;
    public float rotationSpeed = 5f;
    public float collisionRadius = 0.3f;
    public float cameraAngle = 20f;
    public LayerMask collisionMask;

    private Rigidbody ballRb;
    private Quaternion targetRotation;

    void Start()
    {
        ballRb = ball.GetComponent<Rigidbody>();
        targetRotation = transform.rotation;
    }

    void LateUpdate()
    {
        Vector3 velocity = ballRb.linearVelocity;

        if (velocity.magnitude > 0.1f)
        {
            Quaternion yawRotation = Quaternion.LookRotation(velocity.normalized);
            Quaternion tiltRotation = Quaternion.Euler(cameraAngle, yawRotation.eulerAngles.y, 0f);
            targetRotation = Quaternion.Slerp(targetRotation, tiltRotation, Time.deltaTime * rotationSpeed);
        }

        Vector3 desiredOffset = targetRotation * new Vector3(0f, 0f, -distance);
        Vector3 desiredPosition = ball.position + desiredOffset + Vector3.up * height;

        // raycast from ball to desired camera position
        Vector3 directionToCamera = desiredPosition - ball.position;
        float desiredDistance = directionToCamera.magnitude;

        if (Physics.SphereCast(ball.position, collisionRadius, directionToCamera.normalized, out RaycastHit hit, desiredDistance, collisionMask))
        {
            // pull camera to just in front of the hit point
            transform.position = ball.position + directionToCamera.normalized * (hit.distance - collisionRadius);
        }
        else
        {
            transform.position = desiredPosition;
        }

        transform.rotation = targetRotation;
    }
}