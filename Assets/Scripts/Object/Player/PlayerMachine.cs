using System.Collections.Generic;
using UnityEngine;


public class PlayerMachine : ObjectMachine<JumpAttackState>
{
    protected readonly Dictionary<StateType, PlayerBaseState> _states = new();
    protected PlayerBaseState _curState;

    public Player Player { get; private set; }
    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;
    public float JumpForce { get; set; }

    public Transform MainCameraTransform { get; set; }

    public PlayerMachine(Player palyer, JumpAttackState objectState) : base(objectState)
    {
        Player = palyer;
        MainCameraTransform = Camera.main.transform;
        MovementSpeed = palyer.Data.GroundData.BaseSpeed;
        RotationDamping = palyer.Data.GroundData.BaseRotationDamping;
        Init();
    }

    public override void Init()
    {
        _states.Add(StateType.Ground, new PlayerGroundState(this));
        _states.Add(StateType.Idle, new PlayerIdleState(this));
        _states.Add(StateType.Walk, new PlayerWalkState(this));
        _states.Add(StateType.Run, new PlayerRunState(this));
        _states.Add(StateType.Jump, new PlayerJumpState(this));
        _states.Add(StateType.Fall, new PlayerFallState(this));
    }

    public override void Update()
    {
        _curState.Update();
    }

    public override void PhysicsUpdate()
    {
        _curState.FixedUpdate();
    }

    public void HandleInput()
    {
        _curState.HandleInput();
    }

    public override void ChangeState(StateType type)
    {
        _curState?.Exit();
        _curState = _states[type];
        _curState.Init();
    }
}