using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// WaterDamageStrategy.cs
public class WaterDamageStrategy : IDamageStrategy
{
    public float CalculateDamage(float baseDamage, ElementType bulletElement, ElementType enemyElement)
    {
        return enemyElement == ElementType.Fire ? baseDamage * 2f : baseDamage;
    }
}

