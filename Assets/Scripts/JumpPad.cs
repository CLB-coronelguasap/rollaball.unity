using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 15f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // kill vertical velocity first so the jump force is consistent
                Vector3 vel = rb.linearVelocity;
                vel.y = 0f;
                rb.linearVelocity = vel;

                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}