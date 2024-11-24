using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private string targetTag;
    [SerializeField] private int damage;
    [SerializeField] private ElementalMultiplierManager.Element bulletElement;
    
    //Multiplier
    private ElementalMultiplierManager elementMultiplierManager;

    private void Start()
    {
        elementMultiplierManager = gameObject.AddComponent<ElementalMultiplierManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<HealthManager>() != null)
        {
            DamageFunction(other.gameObject, damage, elementMultiplierManager.CalculateElementalMultiplier(bulletElement, other.gameObject.GetComponent<HealthManager>().charElement));
            Destroy(this.gameObject);
        }
            
    }
    

    public void DamageFunction(GameObject target, int damage, int multiplier)
    {
        target.GetComponent<HealthManager>().TakeDamage(damage * multiplier);
            
    }
}
