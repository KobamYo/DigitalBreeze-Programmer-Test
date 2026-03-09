using UnityEngine;

public class GlideState : PlayerState
{
    public GlideState(PlayerStateMachine stateMachine, PlayerController player) : base(stateMachine, player)
    { }

    public override void Enter()
    {
        player.animator.Play("Player_Glide");
    }

    public override void Update()
    {
        if (player.IsGrounded())
            stateMachine.TransitionToState(player.IdleState);
        else if (player.inputHandler.AttackPressed)
            stateMachine.TransitionToState(player.JumpAttackState);
        else if (player.inputHandler.ThrowPressed)
            stateMachine.TransitionToState(player.JumpThrowState);
    }

    public override void FixedUpdate()
    {
        float moveX = player.inputHandler.MoveInput.x * player.moveSpeed;
        float verticalVelocity = player.rb.linearVelocity.y;

        if (verticalVelocity < 0)
            verticalVelocity = -player.glideSpeed;

        player.rb.linearVelocity = new Vector2(moveX, verticalVelocity);
        player.FlipSprite(moveX);
    }
}