// Nombre del archivo: EnemyStateManager.cs
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    public IEnemyState CurrentState { get; private set; }

    // Estados concretos
    public IdleState IdleState { get; private set; }
    public ChasingState ChasingState { get; private set; }
    public AttackingState AttackingState { get; private set; }
    public DeadState DeadState { get; private set; }

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
    public float chaseSpeed = 5f; // Velocidad modificable para persecución

    private void Awake()
    {
        // Instancia de los estados
        IdleState = new IdleState();
        ChasingState = new ChasingState();
        AttackingState = new AttackingState();
        DeadState = new DeadState();

        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Start()
    {
        // Estado inicial
        SwitchState(IdleState);
    }

    private void Update()
    {
        // Actualiza el estado actual
        CurrentState?.UpdateState(this);
    }

    public void SwitchState(IEnemyState newState)
    {
        // Salida del estado actual
        CurrentState?.ExitState(this);

        // Cambiar al nuevo estado
        CurrentState = newState;
        CurrentState?.EnterState(this);
    }
}