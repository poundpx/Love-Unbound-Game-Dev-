using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float runSpeed = 20f;
    public int health = 3;
    public float walkSpeed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDist = .4f;
    public LayerMask groundLayerMask;
    public float JumpHeight = 3f;

    Vector3 velocity;
    bool grounded;
    // Update is called once per frame
    void Update()
    {
        //check for ground
        grounded = Physics.CheckSphere(groundCheck.position, groundDist, groundLayerMask);

        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * walkSpeed * Time.deltaTime);
        //Run
        if (move != null & Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Move(move * runSpeed * Time.deltaTime);
        }

        //jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

}
