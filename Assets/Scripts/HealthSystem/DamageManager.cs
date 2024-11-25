using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    private DamageCalculator _damageCalculator;

    private void Start()
    {
        _damageCalculator = GetComponent<DamageCalculator>();
    }

    public float CalculateDamage(float baseDamage, ElementType bulletElement, ElementType enemyElement)
    {
        // Select strategy based on bullet type
        switch (bulletElement)
        {
            case ElementType.Fire:
                _damageCalculator.SetStrategy(new FireDamageStrategy());
                break;
            case ElementType.Water:
                _damageCalculator.SetStrategy(new WaterDamageStrategy());
                break;
            case ElementType.Nature:
                _damageCalculator.SetStrategy(new NatureDamageStrategy());
                break;
            default:
                _damageCalculator.SetStrategy(new NeutralDamageStrategy());
                break;
        }
        
        float finalDamage = _damageCalculator.CalculateDamage(baseDamage, bulletElement, enemyElement);
        return finalDamage;
    }
}

