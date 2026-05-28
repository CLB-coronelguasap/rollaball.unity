using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
 // Reference to the player GameObject.
 public GameObject player;

 // The distance between the camera and the player.
 private Vector3 offset;

 public float speed = 5.0f;

 // Start is called before the first frame update.
 // void Start()
 //    {
 // // Calculate the initial offset between the camera's position and the player's position.
 //      offset = transform.position - player.transform.position;
 //      float moveHorizontal = Input.GetAxisRaw("Horizontal");
 //    }

    [Header("Target Settings")]
    public Transform target;
    public float distance = 5.0f;

    [Header("Conical & Smoothing Settings")]
    public float coneAngle = 30.0f; // Angle in degrees off the center line
    public float rotationSpeed = 2.0f;
    public float smoothTime = 0.3f;

    private Vector3 currentVelocity;
    private float currentAngle;

    void LateUpdate()
    {
        if (!target) return;

        // 1. Determine the target movement direction
        Vector3 movementDir = target.GetComponent<Rigidbody>() != null 
            ? target.GetComponent<Rigidbody>().linearVelocity 
            : target.forward;

        if (movementDir.magnitude < 0.1f) movementDir = target.forward;
        movementDir.Normalize();

        // 2. Calculate the base conical rotation
        currentAngle += Time.deltaTime * rotationSpeed;
        Quaternion coneOffset = Quaternion.AngleAxis(coneAngle, target.up) * Quaternion.AngleAxis(currentAngle, movementDir);
        Vector3 desiredOffset = coneOffset * movementDir * distance;

        // 3. Smoothly damp the camera's position
        Vector3 targetPosition = target.position - desiredOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);

        // 4. Look directly at the target
        transform.LookAt(target.position);
    }
}

 
 //void Update()
 //{
 //    if (Input.GetKey(KeyCode.RightArrow))
 //    {
 //        transform.position += Vector3.right * speed * Time.deltaTime;
 //        transform.rotation =Quaternion.LookRotation(Vector3.right);
 //    }
 //    if (Input.GetKey(KeyCode.LeftArrow))
 //    {
 //        transform.position += Vector3.left* speed * Time.deltaTime;
 //        transform.rotation =Quaternion.LookRotation(Vector3.left);
 //    }
 //    if (Input.GetKey(KeyCode.UpArrow))
 //    {
 //        transform.position += Vector3.forward * speed * Time.deltaTime;
 //        transform.rotation =Quaternion.LookRotation(Vector3.forward);
 //    }
 //    if (Input.GetKey(KeyCode.DownArrow))
 //    {
 //        transform.position += Vector3.back* speed * Time.deltaTime;
 //        transform.rotation =Quaternion.LookRotation(Vector3.back);
 //    }
 //}
 //void ControlPlayer()
 //  {
 //     float moveHorizontal = Input.GetAxis ("Horizontal");
 //     float moveVertical = Input.GetAxis ("Vertical");
//
 //     if (moveHorizontal == 0 && moveVertical == 0) return;
//
 //        Vector3 movement = new Vector3(moveHorizontal, 0f);
 //        transform.rotation = Quaternion.Euler(45f, moveHorizontal * Time.deltaTime, 0.0f);
 //        transform.position = player.transform.position + offset;
//
 //         if (movement != Vector3.zero) {
 //           transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.2f);
 //         }
//
 //     transform.Translate (movement * speed * Time.deltaTime, Space.Self);
 // }
//
 //  void LateUpdate()
 //  {
 //     ControlPlayer();
 //  }
 //// LateUpdate is called once per frame after all Update functions have been completed.
 ////void LateUpdate()
 //   {
 //// Maintain the same offset between the camera and player throughout the game.
 //     transform.position = player.transform.position + offset;
 //     Vector3 horizontaloffset = new Vector3(moveHorizontal, 0.0f, 0.0f); 
 //     transform.rotation = Quaternion.LookRotation(horizontaloffset);
 //   }
