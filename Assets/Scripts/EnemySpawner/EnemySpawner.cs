using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour, IDamageable
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private int initialPoolSize = 10;
    [SerializeField] private int enemyInstatSpawn = 5;
    [SerializeField] private int enemyRegularSpawn = 2;
    [SerializeField] private float delayBetweenSpawn = 5f;
    [SerializeField] private float distanceToBeginSpawn = 10f;
    [SerializeField] private int hp = 100;

    private ObjectPool<Enemy> enemyPool;
    private Transform player;
    private int currentHp;
    private bool isSpawning;

    private void Start()
    {
        currentHp = hp;
        var characterService = ServiceLocator.Get<ICharactersService>();
        player = characterService.GetPlayerCharacter()?.transform;

        if (player == null)
        {
            Debug.LogError("Player not found in the Service Locator. Make sure the Player is registered correctly.");
        }

        enemyPool = new ObjectPool<Enemy>(enemyPrefab, initialPoolSize);

        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy prefab is not assigned. Please assign it in the Inspector.");
        }

        // Initial Spawn
        SpawnEnemies(enemyInstatSpawn);
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        if (Vector3.Distance(transform.position, player.position) <= distanceToBeginSpawn && !isSpawning)
        {
            isSpawning = true;
            StartCoroutine(RegularSpawn());
        }
    }

    private void SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Enemy enemy = enemyPool.GetObject();
            PositionOnNavMesh(enemy);
            InitializeEnemy(enemy);
        }
    }

    private void PositionOnNavMesh(Enemy enemy)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(spawnPoint.position, out hit, 10.0f, NavMesh.AllAreas))
        {
            enemy.transform.position = hit.position;
            enemy.transform.rotation = spawnPoint.rotation;
            enemy.GetComponent<NavMeshAgent>().Warp(hit.position);

            var navMeshAgent = enemy.GetComponent<NavMeshAgent>();
            if (navMeshAgent != null)
            {
                navMeshAgent.enabled = true;
            }
        }
        else
        {
            Debug.LogError("Failed to place enemy on NavMesh");
            enemy.gameObject.SetActive(false);
        }
    }

    private IEnumerator RegularSpawn()
    {
        while (currentHp > 0)
        {
            yield return new WaitForSeconds(delayBetweenSpawn);
            SpawnEnemies(enemyRegularSpawn);
        }
    }

    private void InitializeEnemy(Enemy enemy)
    {
        EnemyStatsFlyweightFactory statsFactory = new EnemyStatsFlyweightFactory();
        EnemyStatsFlyweight stats = statsFactory.GetFlyweight("Enemy", 100, 10, 5f);

        enemy.SetStats(stats);

        HealthManager healthManager = enemy.GetComponent<HealthManager>();
        EnemyHealthDecorator healthDecorator = new EnemyHealthDecorator(healthManager, this, 5, 2f);
        enemy.SetHealthDecorator(healthDecorator);
    }

    public void Die()
    {
        currentHp = 0;
        StopAllCoroutines();
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            Die();
        }
    }
}
