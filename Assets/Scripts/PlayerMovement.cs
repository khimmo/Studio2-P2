using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 7f;
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private bool canJump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
        }

        
        float hMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(hMovement, 0f, 0f);

        
        float vMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0f, 0f, vMovement);
    }
}
