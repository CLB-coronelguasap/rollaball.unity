// using UnityEngine;
// 
// public class CameraController : MonoBehaviour
// {
//     public GameObject player;
//     private Vector3 offset;
//     public Transform target; // The object to follow
//     public float xRotation = 0f;
//     int DistanceAway = 10;
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         Vector3 PlayerPOS = GameObject.Find("Player").transform.transform.position;
//     }
// 
//     // Update is called once per frame
//     void LateUpdate() {
//         // Follow position
//         transform.position = target.position + offset;
//         transform.rotation = Quaternion.Euler(xRotation, 0f, 0f);
//     }
// }



