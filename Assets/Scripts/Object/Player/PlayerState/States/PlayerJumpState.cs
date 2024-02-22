using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(PlayerMachine playerMachine) : base(playerMachine)
    {
    }

    public override void Init()
    {
        playerMachine.JumpForce = playerMachine.Player.Data.AirData.JumpForce;
        playerMachine.Player.ForceReceiver.Jump(playerMachine.JumpForce);
        base.Init();
        StartAnimation(playerMachine.HashKey.Jump);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(playerMachine.HashKey.Jump);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if(playerMachine.Player.Controller.velocity.y <= 0)
        {
            playerMachine.ChangeState(StateType.Fall);
        }
    }
}
