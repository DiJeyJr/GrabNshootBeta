using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalculator : MonoBehaviour
{
    private IDamageStrategy _strategy;

    public void SetStrategy(IDamageStrategy strategy)
    {
        _strategy = strategy;
    }

    public float CalculateDamage(float baseDamage, ElementType bulletElement, ElementType enemyElement)
    {
        return _strategy.CalculateDamage(baseDamage, bulletElement, enemyElement);
    }
}
