using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public ElementType enemyElement;
    public float health = 100f;
    private float maxHealth;

    [SerializeField] private bool isBoss = false;
    
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
        //Debug.Log($"Salud restante: {health}");
        if (health <= 0)
        {
            Destroy(gameObject);
            if (isBoss)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    
}

