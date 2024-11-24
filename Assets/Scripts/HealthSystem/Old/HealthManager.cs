using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public ElementalMultiplierManager.Element charElement;
    public int health;
    private int defaultMaxHealth;
    
    //HealthBar
    [SerializeField] private GameObject healthBar;
    private HealthBar healthBarScript;
    
    //Healing
    [SerializeField] private int playerHealOnKill = 10;
    private Heal healScript;
    
    GameObject player;
    
    // Evento que se dispara cuando el personaje muere

    private void Start()
    {
        health = maxHealth;
        defaultMaxHealth = maxHealth;
        
        //get HealthBar
        if (healthBar.GetComponent<HealthBar>()!= null)
            healthBarScript = healthBar.GetComponent<HealthBar>();

        healScript = gameObject.AddComponent<Heal>();
        
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (healthBarScript != null)
            healthBarScript.updateHealthBar(health, maxHealth);

        if (Input.GetKeyDown(KeyCode.F3) && CompareTag("Player"))
        {
            maxHealth = 99999999;
            health = maxHealth;
        }
        
        if (Input.GetKeyDown(KeyCode.F4) && CompareTag("Player"))
        {
            maxHealth = defaultMaxHealth;
            health = maxHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            HandleDeath();
        }
    }

    public void Heal(int heal)
    {
        health += heal;
        Debug.Log("Heal " + this.gameObject.name + " > " + heal);
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void HandleDeath()
    {
        if (CompareTag("Enemy"))
        {
            healScript.HealFunction(GameObject.FindGameObjectWithTag("Player").gameObject, playerHealOnKill);
            Destroy(gameObject);
        }
    }

}
