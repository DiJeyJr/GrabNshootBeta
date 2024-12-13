using System.Collections;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private string targetTag;
    [SerializeField] private int damage;
    [SerializeField] private ElementType bulletElement;

    // Multiplier
    private DamageManager damageManager;

    private void Start()
    {
        damageManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<DamageManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        HealthManager healthManager = other.gameObject.GetComponent<HealthManager>();
        if (healthManager != null && other.gameObject.CompareTag(targetTag))
        {
            float finalDamage = damageManager.CalculateDamage(damage, bulletElement, healthManager.charElement);
            DamageFunction(other.gameObject, finalDamage);
            Destroy(this.gameObject);
        }
    }

    public void DamageFunction(GameObject target, float finalDamage)
    {
        HealthManager healthManager = target.GetComponent<HealthManager>();
        if (healthManager != null)
        {
            healthManager.GetDamage((int)finalDamage); // Convertir finalDamage a int si es necesario
        }
    }
}