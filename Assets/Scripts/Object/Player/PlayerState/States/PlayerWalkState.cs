using UnityEngine.InputSystem;

public class PlayerWalkState : PlayerGroundState
{
    public PlayerWalkState(PlayerMachine playerMachine) : base(playerMachine)
    {
    }

    public override void Init()
    {
        playerMachine.MovementSpeedModifier = groundData.WalkSpeedModifier;
        base.Init();
        StartAnimation(playerMachine.HashKey.Walk);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(playerMachine.HashKey.Walk);
    }

    public override void OnRunCanceled(InputAction.CallbackContext context)
    {
        base.OnRunCanceled(context);
        playerMachine.ChangeState(StateType.Run);
    }
}
