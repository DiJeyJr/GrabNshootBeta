// Nombre del archivo: IdleState.cs
using UnityEngine;

public class IdleState : IEnemyState
{
    public void EnterState(EnemyStateManager enemy)
    {
        //Debug.Log("Enemy entered Idle State.");
        enemy.walkPointSet = false;
    }

    public void UpdateState(EnemyStateManager enemy)
    {
        // Patrullaje
        Patrol(enemy);

        // Cambia al estado de persecución si el jugador está en rango
        if (Physics.CheckSphere(enemy.transform.position, enemy.sightRange, enemy.whatIsPlayer))
        {
            enemy.SwitchState(enemy.ChasingState);
        }
    }

    public void ExitState(EnemyStateManager enemy)
    {
        //Debug.Log("Enemy exited Idle State.");
    }

    private void Patrol(EnemyStateManager enemy)
    {
        if (!enemy.walkPointSet)
        {
            SearchWalkPoint(enemy);
        }

        if (enemy.walkPointSet)
        {
            enemy.agent.SetDestination(enemy.walkPoint);
        }

        Vector3 distanceToWalkPoint = enemy.transform.position - enemy.walkPoint;

        // Si llegó al punto, busca uno nuevo
        if (distanceToWalkPoint.magnitude < 1f)
        {
            enemy.walkPointSet = false;
        }
    }

    private void SearchWalkPoint(EnemyStateManager enemy)
    {
        float randomZ = Random.Range(-enemy.walkPointRange, enemy.walkPointRange);
        float randomX = Random.Range(-enemy.walkPointRange, enemy.walkPointRange);

        enemy.walkPoint = new Vector3(
            enemy.transform.position.x + randomX,
            enemy.transform.position.y,
            enemy.transform.position.z + randomZ
        );

        if (Physics.Raycast(enemy.walkPoint, -enemy.transform.up, 2f, enemy.whatIsGround))
        {
            enemy.walkPointSet = true;
        }
    }
}