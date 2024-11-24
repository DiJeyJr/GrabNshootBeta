using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FireDamageStrategy.cs
public class FireDamageStrategy : IDamageStrategy
{
    public float CalculateDamage(float baseDamage, ElementType bulletElement, ElementType enemyElement)
    {
        return enemyElement == ElementType.Nature ? baseDamage * 2f : baseDamage;
    }
}

