
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(PlayerMachine playerMachine) : base(playerMachine)
    {
    }

    public override void Init()
    {
        playerMachine.MovementSpeedModifier = 0f;
        base.Init();
        StartAnimation(playerMachine.HashKey.Idle);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(playerMachine.HashKey.Idle);
    }

    public override void Update()
    {
        base.Update();

        if(playerMachine.MovementInput != Vector2.zero)
        {
            OnMove();
            return;
        }
    }

}
