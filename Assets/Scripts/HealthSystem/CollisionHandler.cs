using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        Enemy enemy = GetComponent<Enemy>();

        if (bullet != null && enemy != null)
        {
            DamageManager damageManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<DamageManager>();
            enemy.TakeDamage(damageManager.CalculateDamage(bullet.baseDamage, bullet.bulletElement, enemy.enemyElement));

            Destroy(bullet.gameObject); // Destruye la bala tras el impacto.
        }
    }
}

