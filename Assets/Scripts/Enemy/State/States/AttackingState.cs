using UnityEngine;
using UnityEngine.AI;

public class AttackingState : IEnemyState
{
    private EnemyStateMachine _enemy;
    private NavMeshAgent _agent;
    private Transform _player;
    private bool _alreadyAttacked = false;
    private float _attackCooldown = 2f;

    public AttackingState(EnemyStateMachine enemy, NavMeshAgent agent, Transform player)
    {
        _enemy = enemy;
        _agent = agent;
        _player = player;
    }

    public void Enter()
    {
        //Debug.Log("Entering Attacking State");
    }


    public void Update()
    {
        _agent.SetDestination(_agent.transform.position);

        if (!_alreadyAttacked)
        {
            Attack();
        }

        if (Vector3.Distance(_agent.transform.position, _player.position) > _enemy.attackRange)
        {
            _enemy.ChangeState(new ChasingState(_enemy, _agent, _player));
        }
    }

    public void Exit()
    {
        //Debug.Log("Exiting Attacking State");
    }

    private void Attack()
    {
        Player.Instance.TakeDamage(10f);
        _alreadyAttacked = true;
        _enemy.StartCoroutine(ResetAttackCooldown());
    }

    private System.Collections.IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(_attackCooldown);
        _alreadyAttacked = false;
    }
}