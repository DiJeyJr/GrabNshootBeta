using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsFlyweightFactory
{
    private Dictionary<string, EnemyStatsFlyweight> flyweights = new Dictionary<string, EnemyStatsFlyweight>();

    public EnemyStatsFlyweight GetFlyweight(string key, int health, int damage, float speed)
    {
        if (!flyweights.ContainsKey(key))
        {
            flyweights[key] = new EnemyStatsFlyweight(health, damage, speed);
        }

        return flyweights[key];
    }
}