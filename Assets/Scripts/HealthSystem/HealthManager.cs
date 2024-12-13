using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour, IHealthSystem
{
    [SerializeField] private bool loadSceneOnDeath = false;
    [SerializeField] private string Scene;
    [SerializeField] private ObjectStats stats;
    public ElementType charElement; // Añade esta línea
    private float health;
    private float maxHealth;
    
    [SerializeField] private GameObject healthBar;
    private HealthBar healthBarScript;

    private void Start()
    {
        maxHealth = health;
        if (healthBar.GetComponent<HealthBar>()!= null)
            healthBarScript = healthBar.GetComponent<HealthBar>();
    }
    
    private void OnEnable()
    {
        health = stats.health;
    }
    
    private void Update()
    {
        if (healthBarScript != null)
            healthBarScript.updateHealthBar(health, maxHealth);
    }


    public float GetHealth()
    {
        return health;
    }

    public void GetDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;
            HandleDeath();
        }
    }

    public void GetHeal(float heal)
    {
        health += heal;
    }

    public void ResetHealth()
    {
        health = stats.health;
    }

    private void HandleDeath()
    {
        if (loadSceneOnDeath)
        {
            SceneManager.LoadScene(Scene);
        }
        
        if (CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}


