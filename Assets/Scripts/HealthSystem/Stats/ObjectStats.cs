using UnityEngine;

[CreateAssetMenu(fileName = "New ObjectStats", menuName = "ObjectStats")]
public class ObjectStats : ScriptableObject
{
    public int health;
    public int damage;
    public float attackCooldown;
    public string targetTag;
}