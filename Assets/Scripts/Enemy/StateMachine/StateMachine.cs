public class StateMachine
{
    private IEnemyState _currentState;

    public void ChangeState(IEnemyState newState)
    {
        _currentState?.Exit();
        
        _currentState = newState;
        
        _currentState.Enter();
    }

    public void Update()
    {
        _currentState?.Update();
    }
}