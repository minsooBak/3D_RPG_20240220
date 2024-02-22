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
    public T HashKey { get; private set; }

    public ObjectMachine(T objectState)
    {
        HashKey = objectState;
    }

    /// <summary>
    /// _states 생성
    /// </summary>
    public abstract void Init();

    public abstract void Update();

    public abstract void PhysicsUpdate();

    public abstract void ChangeState(StateType type);
}
