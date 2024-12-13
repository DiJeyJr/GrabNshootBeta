using UnityEngine;

public class EnemyStatsFlyweight
{
    public int health;
    public int damage;
    public float speed;

    public EnemyStatsFlyweight(int health, int damage, float speed)
    {
        this.health = health;
        this.damage = damage;
        this.speed = speed;
    }
}