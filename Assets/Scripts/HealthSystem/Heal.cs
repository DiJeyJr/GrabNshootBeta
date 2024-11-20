using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public void HealFunction(GameObject target, int amount)
    {
        target.GetComponent<HealthManager>().Heal(amount);
        
    }
}
