using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public float health = 100f;

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

    public void TakeDamage(float damage)
    {
        health -= damage;
        //Debug.Log($"Player health: {health}");

        if (health <= 0)
        {
            //Debug.Log("Player has died.");
        }
    }
}

