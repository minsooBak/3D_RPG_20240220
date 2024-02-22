using UnityEngine.InputSystem;

public class PlayerRunState : PlayerGroundState
{
    public PlayerRunState(PlayerMachine playerMachine) : base(playerMachine)
    {
    }
    public override void Init()
    {
        playerMachine.MovementSpeedModifier = groundData.RunSpeedModifier;
        base.Init();
        StartAnimation(playerMachine.HashKey.Run);
    }

    public override void OnRunStarted(InputAction.CallbackContext context)
    {
        base.OnRunStarted(context);
        playerMachine.ChangeState(StateType.Walk);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(playerMachine.HashKey.Run);
    }
}
