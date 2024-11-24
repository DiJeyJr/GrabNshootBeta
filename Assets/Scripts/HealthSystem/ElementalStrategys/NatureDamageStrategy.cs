using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NatureDamageStrategy.cs
public class NatureDamageStrategy : IDamageStrategy
{
    public float CalculateDamage(float baseDamage, ElementType bulletElement, ElementType enemyElement)
    {
        return enemyElement == ElementType.Water ? baseDamage * 2f : baseDamage;
    }
}
