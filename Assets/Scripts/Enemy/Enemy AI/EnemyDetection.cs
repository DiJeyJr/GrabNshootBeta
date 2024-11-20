using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private float detectDistance = 20f;
    
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public bool detectPLayer()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= detectDistance)
        {
            return true;
        }
        return false;
    }
}
