using UnityEngine.InputSystem;

public class PlayerAirState : PlayerBaseState
{
    public PlayerAirState(PlayerMachine playerMachine) : base(playerMachine)
    {
    }

    public override void Init()
    {
        base.Init();
        StartAnimation(playerMachine.HashKey.Air);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(playerMachine.HashKey.Air);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
