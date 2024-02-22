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
    public readonly Dictionary<StateType, IState> _states = new();
    protected IState CurState { get; private set; }

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
        CurState.Update();
    }

    public void PhysicsUpdate()
    {
        CurState.FixedUpdate();
    }

    public void ChangeState(StateType type)
    {
        CurState?.Exit();
        CurState = _states[type];
        CurState.Init();
    }
}
