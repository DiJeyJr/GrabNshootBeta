using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        HealthManager enemy = GetComponent<HealthManager>();

        if (bullet != null && enemy != null)
        {
            DamageManager damageManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<DamageManager>();
            float finalDamage = damageManager.CalculateDamage(bullet.baseDamage, bullet.bulletElement, enemy.charElement);
            enemy.GetDamage((int)finalDamage); // Convertir finalDamage a int si es necesario

            Destroy(bullet.gameObject);
        }
    }
}