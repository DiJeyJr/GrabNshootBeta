using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService
{
    private GameObject player;
    
    public PlayerService(GameObject player)
    {
        this.player = player;
    }

    public GameObject GetPlayer()
    {
        return player;
    }
    
    
}

