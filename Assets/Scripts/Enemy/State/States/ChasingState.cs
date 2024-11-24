// Nombre del archivo: ChasingState.cs
using UnityEngine;

public class ChasingState : IEnemyState
{
    public void EnterState(EnemyStateManager enemy)
    {
        //Debug.Log("Enemy started chasing the player.");
        enemy.agent.speed = enemy.chaseSpeed; // Ajusta la velocidad de persecución
    }

    public void UpdateState(EnemyStateManager enemy)
    {
        // Persigue al jugador
        enemy.agent.SetDestination(enemy.player.position);

        // Gira para mirar al jugador
        Vector3 direction = (enemy.player.position - enemy.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, lookRotation, Time.deltaTime * 5f);

        // Cambia al estado de ataque si está en rango de ataque
        if (Physics.CheckSphere(enemy.transform.position, enemy.attackRange, enemy.whatIsPlayer))
        {
            enemy.SwitchState(enemy.AttackingState);
        }
    }

    public void ExitState(EnemyStateManager enemy)
    {
        //Debug.Log("Enemy stopped chasing the player.");
    }
}