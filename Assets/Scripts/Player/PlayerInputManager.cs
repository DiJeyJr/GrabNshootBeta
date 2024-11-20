using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    //Input Scripts definie
    public PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    
    //PlayerMotor
    private PlayerMotor playerMotor;

    //PlayerLook (Camera Rotation)
    private PlayerLook playerLook;
    
    //Corusor Lock
    private CursorLock cursorLock;
    
    private void Awake()
    {
        //Getting Input
        playerInput = new PlayerInput();
        onFoot = playerInput.onFoot;
        
        //Getting Motor
        playerMotor = GetComponent<PlayerMotor>();
        
        //Jump
        onFoot.Jump.performed += ctx => playerMotor.Jump();
        
        //Look (Camera Rotation)
        playerLook = GetComponent<PlayerLook>();
        
        //Cursor Lock
        cursorLock = GetComponent<CursorLock>();

        onFoot.CursorLock.performed += ctx => cursorLock.enabled = false;
        onFoot.CursorLock.canceled += ctx => cursorLock.enabled = true;
        
        //turn weapon on
        transform.GetChild(1).gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        //Execute player movement
        playerMotor.ProcessMove(onFoot.Movement.ReadValue<Vector2>(), onFoot.Sprint.IsPressed());
    }

    private void LateUpdate()
    {
        //Execute camera rotation if cursor not locked
        if (cursorLock.enabled)
        {
            playerLook.ProcessLook(onFoot.CameraGyro.ReadValue<Vector2>());
        }
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
