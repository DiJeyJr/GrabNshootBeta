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
        // Selección de la estrategia según el elemento de la bala.
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

        // Cálculo del daño final.
        float finalDamage = _damageCalculator.CalculateDamage(baseDamage, bulletElement, enemyElement);
        return finalDamage;

        // Aplica el daño al enemigo.
        //Debug.Log($"Se aplicó {finalDamage} de daño al enemigo.");
    }
}

