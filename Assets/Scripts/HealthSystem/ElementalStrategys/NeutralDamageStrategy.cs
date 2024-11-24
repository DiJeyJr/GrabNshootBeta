using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NeutralDamageStrategy.cs
public class NeutralDamageStrategy : IDamageStrategy
{
    public float CalculateDamage(float baseDamage, ElementType bulletElement, ElementType enemyElement)
    {
        return baseDamage; // Daño estándar.
    }
}

