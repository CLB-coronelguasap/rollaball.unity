using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public Camera playerCamera; // drag your camera in here
    private int collectibleAmount;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        collectibleAmount = GameObject.FindGameObjectsWithTag("PickUp").Length;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded);
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }


    void OnCollisionStay() {
        isGrounded = true;
    }

    
    void OnCollisionExit() {
        isGrounded = false;
    }
    void FixedUpdate()
    {
        // get camera's forward and right but flatten them so vertical tilt doesn't affect movement
        Vector3 camForward = playerCamera.transform.forward;
        Vector3 camRight = playerCamera.transform.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 movement = (camForward * movementY) + (camRight * movementX);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    private void OnCollisionEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }

        if (other.gameObject.CompareTag("finish") && count >= collectibleAmount)
        {
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win! All Collectibles Collected!";
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            rb.linearVelocity = Vector3.zero;
            rb.isKinematic = true;
        }
        else if (other.gameObject.CompareTag("finish") && count != collectibleAmount)
        {
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win! But You Didn't Collect Everything!";
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            rb.linearVelocity = Vector3.zero;
            rb.isKinematic = true;
        }
        else if (other.gameObject.CompareTag("finish") && count == 0)
        {
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose! How did you not collect anything?";
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            rb.linearVelocity = Vector3.zero;
            rb.isKinematic = true;
        }
    }
}
