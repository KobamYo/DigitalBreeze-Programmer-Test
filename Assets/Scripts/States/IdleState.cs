using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState(PlayerStateMachine stateMachine, PlayerController player) : base(stateMachine, player)
    { }

    public override void Enter()
    {
        player.animator.Play("Player_Idle");
    }

    public override void Update()
    {
        if (player.inputHandler.MoveInput.x != 0)
            stateMachine.TransitionToState(player.RunState);
        else if (player.inputHandler.JumpPressed && player.IsGrounded())
            stateMachine.TransitionToState(player.JumpState);
        else if (player.inputHandler.AttackPressed)
            stateMachine.TransitionToState(player.AttackState);
        else if (player.inputHandler.ThrowPressed)
            stateMachine.TransitionToState(player.ThrowState);
        else if (player.inputHandler.SlidePressed && player.IsGrounded())
            stateMachine.TransitionToState(player.SlideState);
    }

    public override void FixedUpdate()
    {
        player.rb.linearVelocity = new Vector2(0, player.rb.linearVelocity.y);
    }
}