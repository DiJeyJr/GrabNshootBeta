using UnityEngine;

public class DeadState : IEnemyState
{
    public void Enter()
    {
        //Debug.Log("Enemy is dead.");
    }

    public void Update()
    {
        // No hay lógica aquí porque el enemigo está muerto
    }

    public void Exit()
    {
        // Este estado no tiene salida
    }
}