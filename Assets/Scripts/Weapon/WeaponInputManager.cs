using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInputManager : MonoBehaviour
{
    //Input Scripts definie
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    
    //Shoot Script call
    private ShootFunction shootFunction;
    
    //Chamber rotation and bullet getter call
    private ChamberRotation chamberRotation;
    
    //Collet Bullet call
    private CollectBullet collectBullet;

    private void Awake()
    {
        //Getting Input
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputManager>().playerInput;
        onFoot = playerInput.onFoot;
        
        //Chamber rotation and bullet getter
        chamberRotation = GetComponent<ChamberRotation>();
        onFoot.Reload.started += ctx => chamberRotation.RotateChamber();
        
        //Shoot script
        shootFunction = GetComponent<ShootFunction>();
        onFoot.Shoot.performed += ctx => shootFunction.Shoot(chamberRotation.chambers[0]);

        onFoot.Shoot.canceled += ctx => shootFunction.CoolDown();
        
        //Collect Bullet
        collectBullet = GetComponent<CollectBullet>();
        onFoot.Interact.started += ctx => collectBullet.CollectBulletFunction();
    }

    private void Update()
    {
        chamberRotation.BulletInChamberPositionUpdate();
    }
}
