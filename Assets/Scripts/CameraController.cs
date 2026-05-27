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
 void Start()
    {
 // Calculate the initial offset between the camera's position and the player's position.
      offset = transform.position - player.transform.position;
      float moveHorizontal = Input.GetAxisRaw("Horizontal");
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
 void ControllPlayer()
   {
      float moveHorizontal = Input.GetAxis ("Horizontal");
      float moveVertical = Input.GetAxis ("Vertical");

      if (moveHorizontal == 0 && moveVertical == 0) return;

         Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
         transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);

          if (movement != Vector3.zero) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f);
          }

      transform.Translate (movement * speed * Time.deltaTime, Space.World);
  }

 // LateUpdate is called once per frame after all Update functions have been completed.
 //void LateUpdate()
 //   {
 //// Maintain the same offset between the camera and player throughout the game.
 //     transform.position = player.transform.position + offset;
 //     Vector3 horizontaloffset = new Vector3(moveHorizontal, 0.0f, 0.0f); 
 //     transform.rotation = Quaternion.LookRotation(horizontaloffset);
 //   }
}