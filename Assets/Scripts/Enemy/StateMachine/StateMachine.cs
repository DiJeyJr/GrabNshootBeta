// Nombre del archivo: StateMachine.cs
using UnityEngine;

public class StateMachine
{
    private IEnemyState _currentState;

    public void ChangeState(IEnemyState newState)
    {
        // Salir del estado actual
        _currentState?.Exit();

        // Cambiar al nuevo estado
        _currentState = newState;

        // Entrar al nuevo estado
        _currentState.Enter();
    }

    public void Update()
    {
        // Actualizar el estado actual
        _currentState?.Update();
    }
}