using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Prototype", menuName = "EnemyPrototype")]
public class EnemyPrototype : ScriptableObject
{
    public GameObject enemyPrefab;

    public GameObject Clone(Vector3 position, Quaternion rotation)
    {
        return Instantiate(enemyPrefab, position, rotation);
    }
}