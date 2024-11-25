using UnityEngine;
using UnityEngine.AI;

public class IdleState : IEnemyState
{
    private EnemyStateMachine _enemy;
    private NavMeshAgent _agent;
    private Transform _player;
    private Vector3 _walkPoint;
    private bool _walkPointSet;
    private float _walkPointRange = 10f;

    public IdleState(EnemyStateMachine enemy, NavMeshAgent agent, Transform player)
    {
        _enemy = enemy;
        _agent = agent;
        _player = player;
    }

    public void Enter()
    {
        _walkPointSet = false;
    }

    public void Update()
    {
        Patrol();
        
        if (Vector3.Distance(_agent.transform.position, _player.position) < _enemy.sightRange)
        {
            _enemy.ChangeState(new ChasingState(_enemy, _agent, _player));
        }
    }

    public void Exit()
    {
        //Debug.Log("Exiting Idle State");
    }

    private void Patrol()
    {
        if (!_walkPointSet)
        {
            SearchWalkPoint();
        }

        if (_walkPointSet)
        {
            _agent.SetDestination(_walkPoint);
        }

        Vector3 distanceToWalkPoint = _agent.transform.position - _walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            _walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-_walkPointRange, _walkPointRange);
        float randomX = Random.Range(-_walkPointRange, _walkPointRange);

        _walkPoint = new Vector3(
            _agent.transform.position.x + randomX,
            _agent.transform.position.y,
            _agent.transform.position.z + randomZ
        );

        _walkPointSet = true;
    }
}