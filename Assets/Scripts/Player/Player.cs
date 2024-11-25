using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public float health = 100f;
    private float maxHealth;

    [SerializeField] private GameObject healthBar;
    private HealthBar healthBarScript;

    private void Start()
    {
        maxHealth = health;
        if (healthBar.GetComponent<HealthBar>()!= null)
            healthBarScript = healthBar.GetComponent<HealthBar>();
    }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Update()
    {
        if (healthBarScript != null)
            healthBarScript.updateHealthBar(health, maxHealth);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}

