using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public ObjectData Data { get; private set; }
    public PlayerInputs Input { get; private set; }
    public PlayerInputs.KeyboardActions PlayerActions {  get; private set; }
    public Animator Animator { get; private set; }
    public CharacterController Controller { get; private set; }
    private PlayerMachine stateMachine;
    public ForceReceiver ForceReceiver { get; private set; }

    private void Awake()
    {
        Input = new PlayerInputs();
        PlayerActions = Input.Keyboard;
        Animator = GetComponentInChildren<Animator>();
        Controller = GetComponent<CharacterController>();
        ForceReceiver = GetComponent<ForceReceiver>();
        stateMachine = new PlayerMachine(this, new JumpAttackState());
    }

    private void OnEnable()
    {
        PlayerActions.Enable();
    }

    private void OnDisable()
    {
        PlayerActions.Disable();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        stateMachine.ChangeState(StateType.Idle);
    }

    private void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }
}