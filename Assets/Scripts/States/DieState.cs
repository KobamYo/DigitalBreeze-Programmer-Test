using UnityEngine;

public class DieState : PlayerState
{
    private float timer = 2f;

    public DieState(PlayerStateMachine stateMachine, PlayerController player) : base(stateMachine, player)
    { }

    public override void Enter()
    {
        player.animator.Play("Player_Dead");
        
        player.inputHandler.enabled = false;
        
        player.rb.linearVelocity = Vector2.zero;
        player.rb.isKinematic = true;
        
        player.collider.enabled = false;
    }

    public override void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            GameObject.Destroy(player.gameObject);
    }

    public override void Exit()
    {
        player.inputHandler.enabled = true;
        player.rb.isKinematic = false;
        player.collider.enabled = true;
    }
}