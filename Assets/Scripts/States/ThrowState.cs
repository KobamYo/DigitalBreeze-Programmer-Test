using UnityEngine;

public class ThrowState : PlayerState
{
    private float timer;

    public ThrowState(PlayerStateMachine stateMachine, PlayerController player) : base(stateMachine, player)
    { }

    public override void Enter()
    {
        player.animator.Play("Player_Throw");
        timer = player.throwDuration;
        player.SpawnProjectile();
    }

    public override void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
            stateMachine.TransitionToState(player.IdleState);
    }

    public override void FixedUpdate()
    {
        player.rb.linearVelocity = new Vector2(0, player.rb.linearVelocity.y);
    }
}