using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    //movement
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 5f;     
        
    Vector3 velocity;
    bool isGrounded;
    bool jumpNextFrame;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpNextFrame = true;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //groundcheck        
        isGrounded = controller.isGrounded;        

        //jump
        if (jumpNextFrame && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -gravity);
        }
            jumpNextFrame = false;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //move
        Vector3 move = transform.right * x + transform.forward * z;
        velocity.y += gravity * Time.fixedDeltaTime;
        controller.Move((move * speed + velocity) * Time.fixedDeltaTime);       
    }
    
}
