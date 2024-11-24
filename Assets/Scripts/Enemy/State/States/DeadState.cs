using UnityEngine;

public class DeadState : IEnemyState
{
    public void EnterState(EnemyStateManager enemy)
    {
        //Debug.Log("Enemy is dead.");
        GameObject.Destroy(enemy.gameObject); // Destruye al enemigo
    }

    public void UpdateState(EnemyStateManager enemy)
    {
        // No hay lógica aquí porque el enemigo está muerto
    }

    public void ExitState(EnemyStateManager enemy)
    {
        // Este estado no tiene salida
    }
}