using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundState : PlayerBaseState
{
    public PlayerGroundState(PlayerMachine playerMachine) : base(playerMachine)
    {
    }

    public override void Init()
    {
        base.Init();
        StartAnimation(playerMachine.HashKey.Ground);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(playerMachine.HashKey.Ground);
    }

    public override void Update()
    {
        base.Update();

    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if(!playerMachine.Player.Controller.isGrounded
            && playerMachine.Player.Controller.velocity.y < (Physics.gravity.y * 15f) * Time.fixedDeltaTime)
        {
            playerMachine.ChangeState(StateType.Fall);
            return;
        }
    }

    public override void OnMovementCanceled(InputAction.CallbackContext context)
    {
        if (playerMachine.MovementInput == Vector2.zero) return;

        playerMachine.ChangeState(StateType.Idle);

        base.OnMovementCanceled(context);
    }

    public override void OnJumpStart(InputAction.CallbackContext context)
    {
        base.OnJumpStart(context);
        playerMachine.ChangeState(StateType.Jump);
    }

    protected virtual void OnMove()
    {
        playerMachine.ChangeState(StateType.Walk);
    }
}
