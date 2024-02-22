using UnityEngine;

public class ObjectState  //고정 NPC
{
    public readonly int Idle = Animator.StringToHash("Idle");
    public readonly int Hit = Animator.StringToHash("Hit");
}

public class MovementState : ObjectState//움직이는 Object
{
    public readonly int Run = Animator.StringToHash("Run");
    public readonly int Walk = Animator.StringToHash("Walk");
}

public class AttackState : ObjectState
{
    public readonly int Attack = Animator.StringToHash("Attack");
}

public class MoveAttackState : ObjectState//공격 가능한 Object
{
    public readonly int Run = Animator.StringToHash("Run");
    public readonly int Walk = Animator.StringToHash("Walk");
    public readonly int Attack = Animator.StringToHash("Attack");
    public readonly int Fall = Animator.StringToHash("Fall");
}

public class JumpAttackState : ObjectState
{
    public readonly int Run = Animator.StringToHash("Run");
    public readonly int Walk = Animator.StringToHash("Walk");
    public readonly int Attack = Animator.StringToHash("Attack");
    public readonly int Jump = Animator.StringToHash("Jump");
    public readonly int Fall = Animator.StringToHash("Fall");
    public readonly int Ground = Animator.StringToHash("@Ground");
    public readonly int Air = Animator.StringToHash("@Air");
}