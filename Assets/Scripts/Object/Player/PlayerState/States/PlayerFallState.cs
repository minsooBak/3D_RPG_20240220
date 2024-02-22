public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(PlayerMachine playerMachine) : base(playerMachine)
    {
    }

    public override void Init()
    {
        base.Init();
        StartAnimation(playerMachine.HashKey.Fall);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(playerMachine.HashKey.Fall);
    }

    public override void Update()
    {
        base.Update();

        if(playerMachine.Player.Controller.isGrounded)
        {
            playerMachine.ChangeState(StateType.Idle);
            return;
        }
    }
}
