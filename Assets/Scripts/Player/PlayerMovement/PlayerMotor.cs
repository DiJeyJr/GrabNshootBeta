using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    //Player Controller and speed
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float defaultSpeed;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float sprintSpeedFactor = 2f;
    
    //Gravity
    private bool isGrounded;
    [SerializeField] private float gravity = -9.81f;

    //Jump
    [SerializeField] private float jumpHeight = 2f;
    
    private void Start()
    {
        //Getting Controller
        controller = GetComponent<CharacterController>();
            
        defaultSpeed = speed;
    }

    private void Update()
    {
        //Checking if player is touching Grass ;)
        isGrounded = controller.isGrounded;

        if (Input.GetKeyDown(KeyCode.F1))
        {
            speed += 2.5f;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            speed = defaultSpeed;
        }
    }

    public void ProcessMove(Vector2 input, bool sprint)
    {
        float processedSpeed;
        processedSpeed = speed;
        if (sprint)
        {
            processedSpeed = processedSpeed * sprintSpeedFactor;
        }
        
        //Input Read
        Vector3 moveDir = Vector3.zero;
        moveDir.x = input.x;
        moveDir.z = input.y;
        
        //Apply Input
        controller.Move(transform.TransformDirection(moveDir) * processedSpeed * Time.deltaTime);
        
        //Gravity
        playerVelocity.y += gravity * Time.deltaTime;
        //if grounded reduce gravity force (2f symbolic number of gravity force when grounded to avoid floor bugs)
        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        //Apply Gravity
        controller.Move(playerVelocity * Time.deltaTime);
        
        
    }

    public void Jump()
    {
        if (isGrounded)
        {
            //-3f is force of negative gravity applied when jumping
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
        }
    }
}
