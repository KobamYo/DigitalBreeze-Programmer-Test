using UnityEngine;

public class RunState : PlayerState
{
    public RunState(PlayerStateMachine stateMachine, PlayerController player) : base(stateMachine, player)
    { }

    public override void Enter()
    {
        player.animator.Play("Player_Run");
    }

    public override void Update()
    {
        if (player.inputHandler.MoveInput.x == 0)
            stateMachine.TransitionToState(player.IdleState);
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
        float moveX = player.inputHandler.MoveInput.x * player.moveSpeed;
        player.rb.linearVelocity = new Vector2(moveX, player.rb.linearVelocity.y);
        player.FlipSprite(moveX);
    }
}