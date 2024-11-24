using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform healthBar;

    private float xScalebar;

    public void updateHealthBar(float HealthValue, float MaxHealthValue)
    {
        float maxHealth = MaxHealthValue;
        float currentHealth = HealthValue;
        float healthPercentage = currentHealth / maxHealth;
        
        healthBar.transform.localScale = new Vector3(healthPercentage, 1, 1);
    }
}
