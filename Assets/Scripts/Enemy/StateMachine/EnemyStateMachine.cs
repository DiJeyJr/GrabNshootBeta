// Nombre del archivo: EnemyStateMachine.cs
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private StateMachine _stateMachine;

    [Header("State Settings")]
    public float sightRange = 10f;
    public float attackRange = 2f;
    public float patrolSpeed = 3f;
    public float chaseSpeed = 5f;

    private Transform _player;
    private UnityEngine.AI.NavMeshAgent _agent;

    private void Awake()
    {
        _stateMachine = new StateMachine();
        _player = GameObject.FindWithTag("Player").transform;
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Start()
    {
        // Inicializa con el estado Idle
        _stateMachine.ChangeState(new IdleState(this, _agent, _player));
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    public void ChangeState(IEnemyState newState)
    {
        _stateMachine.ChangeState(newState);
    }
}