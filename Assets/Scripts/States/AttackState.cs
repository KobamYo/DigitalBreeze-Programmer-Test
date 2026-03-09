using UnityEngine;

public class AttackState : PlayerState
{
    private float timer;

    public AttackState(PlayerStateMachine stateMachine, PlayerController player) : base(stateMachine, player)
    { }

    public override void Enter()
    {
        player.animator.Play("Player_Attack");
        timer = player.attackDuration;
        player.attackHitbox.EnableHitbox();
    }

    public override void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            player.attackHitbox.DisableHitbox();
            stateMachine.TransitionToState(player.IdleState);
        }
    }

    public override void FixedUpdate()
    {
        player.rb.linearVelocity = new Vector2(0, player.rb.linearVelocity.y);
    }

    public override void Exit()
    {
        player.attackHitbox.DisableHitbox();
    }
}