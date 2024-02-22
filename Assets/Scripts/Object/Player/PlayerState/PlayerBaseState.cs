using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBaseState : IState
{
    protected PlayerMachine playerMachine;
    protected readonly PlayerGroundData groundData;

    public PlayerBaseState(PlayerMachine playerMachine)
    {
        this.playerMachine = playerMachine;
        groundData = playerMachine.Player.Data.GroundData;
    }

    public virtual void Init()
    {
        AddInputActionsCallBacks();
    }
    public virtual void Exit()
    {
        RemoveInputActionsCallBacks();
    }

    public virtual void FixedUpdate()
    {
    }


    public virtual void Update()
    {
        Move();
    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
    }

    protected virtual void AddInputActionsCallBacks()
    {
        PlayerInputs.KeyboardActions actions = playerMachine.Player.PlayerActions;
        actions.Move.canceled += OnMovementCanceled;
        actions.Run.started += OnRunStarted;
        actions.Run.canceled += OnRunCanceled;
        actions.Jump.canceled += OnJumpStart;

    }

    protected virtual void RemoveInputActionsCallBacks()
    {
        PlayerInputs.KeyboardActions actions = playerMachine.Player.PlayerActions;
        actions.Move.canceled -= OnMovementCanceled;
        actions.Run.started -= OnRunStarted;
        actions.Run.canceled -= OnRunCanceled;
        actions.Jump.canceled -= OnJumpStart;
    }

    public virtual void OnJumpStart(InputAction.CallbackContext context) { }

    public virtual void OnRunStarted(InputAction.CallbackContext context) {}
    public virtual void OnRunCanceled(InputAction.CallbackContext context) { }

    public virtual void OnMovementCanceled(InputAction.CallbackContext context) {}

    private void ReadMovementInput()
    {
        playerMachine.MovementInput = playerMachine.Player.PlayerActions.Move.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 dir = GetMovementDirection();

        Rotate(dir);

        Move(dir);
    }

    private Vector3 GetMovementDirection()
    {
        Vector3 forward = playerMachine.MainCameraTransform.forward;
        Vector3 right = playerMachine.MainCameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        return forward * playerMachine.MovementInput.y + right * playerMachine.MovementInput.x;
    }

    private void Rotate(Vector3 dir)
    {
        if(dir != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(dir);
            Transform playerTransform = playerMachine.Player.transform;
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRot, playerMachine.RotationDamping * Time.deltaTime);
        }
    }

    private void Move(Vector3 dir)
    {
        float speed = GetMovementSpeed();
        playerMachine.Player.Controller.Move(
            ((dir * speed) 
            + playerMachine.Player.ForceReceiver.Movement) 
            * Time.deltaTime
            );
    }

    private float GetMovementSpeed()
    {
        return playerMachine.MovementSpeed * playerMachine.MovementSpeedModifier;
    }

    protected void StartAnimation(int animationHash)
    {
        playerMachine.Player.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        playerMachine.Player.Animator.SetBool(animationHash, false);
    }
}
