// Nombre del archivo: EnemyStateManager.cs
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{/*
    public IEnemyState CurrentState { get; private set; }

    // Estados concretos
    private IdleState _idleState;
    private ChasingState _chasingState;
    private AttackingState _attackingState;
    private DeadState _deadState;

    [Header("NavMesh Settings")]
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    [Header("Patrol Settings")]
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    [Header("Enemy Settings")]
    public float sightRange;
    public float attackRange;
    public float chaseSpeed = 5f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;

        // Instanciamos los estados con los parámetros necesarios
        _idleState = new IdleState();
        _chasingState = new ChasingState();
        _attackingState = new AttackingState();
        _deadState = new DeadState();
    }

    private void Start()
    {
        // Estado inicial
        SwitchState(_idleState);
    }

    private void Update()
    {
        CurrentState?.UpdateState(this);
    }

    public void SwitchState(IEnemyState newState)
    {
        CurrentState?.ExitState(this);
        CurrentState = newState;
        CurrentState.EnterState(this);
    }*/
}