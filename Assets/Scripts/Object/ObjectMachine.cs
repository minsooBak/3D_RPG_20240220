using System.Collections.Generic;

public enum StateType
{
    Idle,
    Run,
    Walk,
    Hit,
    Jump,
    Fall,
    Attack,
    Ground,
    Air
}

public abstract class ObjectMachine<T> where T : ObjectState
{
    protected readonly Dictionary<StateType, PlayerBaseState> _states = new();
    protected PlayerBaseState _curState;
    public T HashKey { get; private set; }

    public ObjectMachine(T objectState)
    {
        HashKey = objectState;
    }

    /// <summary>
    /// _states 생성
    /// </summary>
    public abstract void Init();

    public void Update()
    {
        _curState.Update();
    }

    public void PhysicsUpdate()
    {
        _curState.FixedUpdate();
    }

    public void HandleInput()
    {
        _curState.HandleInput();
    }

    public void ChangeState(StateType type)
    {
        _curState?.Exit();
        _curState = _states[type];
        _curState.Init();
    }
}
