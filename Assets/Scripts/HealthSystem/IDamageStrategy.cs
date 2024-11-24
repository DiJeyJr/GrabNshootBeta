using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageStrategy
{
    float CalculateDamage(float baseDamage, ElementType bulletElement, ElementType enemyElement);
}

