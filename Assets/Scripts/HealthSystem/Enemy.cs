using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyStatsFlyweight stats;
    private IHealthSystem healthDecorator;

    public void SetStats(EnemyStatsFlyweight stats)
    {
        this.stats = stats;
    }

    public void SetHealthDecorator(IHealthSystem healthDecorator)
    {
        this.healthDecorator = healthDecorator;
    }

    public Enemy Clone(Vector3 position, Quaternion rotation)
    {
        GameObject clone = Instantiate(gameObject, position, rotation);
        Enemy clonedEnemy = clone.GetComponent<Enemy>();
        
        clonedEnemy.SetStats(this.stats);
        clonedEnemy.SetHealthDecorator(this.healthDecorator);

        return clonedEnemy;
    }
}