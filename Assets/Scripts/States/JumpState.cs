using UnityEngine;

public class JumpState : PlayerState
{
    public JumpState(PlayerStateMachine stateMachine, PlayerController player) : base(stateMachine, player)
    { }

    public override void Enter()
    {
        player.animator.Play("Player_Jump");
        if (player.IsGrounded())
            player.rb.linearVelocity = new Vector2(player.rb.linearVelocity.x, player.jumpForce);
    }

    public override void Update()
    {
        if (player.rb.linearVelocity.y < 0)
            stateMachine.TransitionToState(player.GlideState);
        else if (player.inputHandler.AttackPressed)
            stateMachine.TransitionToState(player.JumpAttackState);
        else if (player.inputHandler.ThrowPressed)
            stateMachine.TransitionToState(player.JumpThrowState);
    }

    public override void FixedUpdate()
    {
        float moveX = player.inputHandler.MoveInput.x * player.moveSpeed;
        player.rb.linearVelocity = new Vector2(moveX, player.rb.linearVelocity.y);
    }
}