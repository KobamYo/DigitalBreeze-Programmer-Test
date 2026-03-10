using UnityEngine;

public class JumpThrowState : PlayerState
{
    private float timer;

    public JumpThrowState(PlayerStateMachine stateMachine, PlayerController player) : base(stateMachine, player)
    { }

    public override void Enter()
    {
        player.animator.Play("Player_JumpThrow");
        timer = player.throwDuration;
        player.SpawnProjectile();
    }

    public override void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (player.IsGrounded())
            {
                if (player.inputHandler.MoveInput.x != 0)
                    stateMachine.TransitionToState(player.RunState);
                else
                    stateMachine.TransitionToState(player.IdleState);
            }
            else if (player.rb.linearVelocity.y < 0)
            {
                stateMachine.TransitionToState(player.GlideState);
            }
            else
            {
                stateMachine.TransitionToState(player.JumpState);
            }
        }
    }

    public override void FixedUpdate()
    {
        float moveX = player.inputHandler.MoveInput.x * player.moveSpeed * 0.8f;
        player.rb.linearVelocity = new Vector2(moveX, player.rb.linearVelocity.y);
    }
}