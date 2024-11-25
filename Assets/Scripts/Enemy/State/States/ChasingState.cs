// Nombre del archivo: ChasingState.cs
using UnityEngine;
using UnityEngine.AI;

public class ChasingState : IEnemyState
{
    private EnemyStateMachine _enemy;
    private NavMeshAgent _agent;
    private Transform _player;

    public ChasingState(EnemyStateMachine enemy, NavMeshAgent agent, Transform player)
    {
        _enemy = enemy;
        _agent = agent;
        _player = player;
    }

    public void Enter()
    {
        //Debug.Log("Entering Chasing State");
        _agent.speed = _enemy.chaseSpeed;
    }

    public void Update()
    {
        _agent.SetDestination(_player.position);
        
        if (Vector3.Distance(_agent.transform.position, _player.position) < _enemy.attackRange)
        {
            _enemy.ChangeState(new AttackingState(_enemy, _agent, _player));
        }
    }

    public void Exit()
    {
        //Debug.Log("Exiting Chasing State");
    }
}