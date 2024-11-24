using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ElementType enemyElement; // Tipo de elemento del enemigo.
    public float health = 100f;      // Salud del enemigo.
    private float maxHealth;
    
    [SerializeField] private GameObject healthBar;
    private HealthBar healthBarScript;
    
    private void Start()
    {
        maxHealth = health;
        if (healthBar.GetComponent<HealthBar>()!= null)
            healthBarScript = healthBar.GetComponent<HealthBar>();
    }
    
    private void Update()
    {
        if (healthBarScript != null)
            healthBarScript.updateHealthBar(health, maxHealth);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"Salud restante: {health}");
        if (health <= 0)
        {
            Destroy(gameObject); // Elimina al enemigo si la salud llega a 0.
        }
    }

    
}

