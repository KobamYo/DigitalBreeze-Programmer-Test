using UnityEngine;

public class SlideState : PlayerState
{
    private float timer;
    private float slideDirection;

    public SlideState(PlayerStateMachine stateMachine, PlayerController player) : base(stateMachine, player)
    { }

    public override void Enter()
    {
        player.animator.Play("Player_Slide");
        timer = player.slideDuration;
        slideDirection = Mathf.Sign(player.transform.localScale.x);
    }

    public override void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
            stateMachine.TransitionToState(player.IdleState);
    }

    public override void FixedUpdate()
    {
        player.rb.linearVelocity = new Vector2(slideDirection * player.slideSpeed, player.rb.linearVelocity.y);
    }
}