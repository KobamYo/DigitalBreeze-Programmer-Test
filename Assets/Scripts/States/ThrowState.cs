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
        float direction = Mathf.Sign(player.transform.localScale.x);
        Vector2 throwDir = new Vector2(direction, 0);

        if (player.projectilePrefab != null && player.throwOrigin != null)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, -90);
            GameObject proj = GameObject.Instantiate(player.projectilePrefab, player.throwOrigin.position, rotation);
            Quaternion rot;

            if (direction > 0)
                rot = Quaternion.Euler(0, 0, -90);
            else
                rot = Quaternion.Euler(0, 0, 90);
                
            proj.transform.rotation = rot;
            Projectile projectileScript = proj.GetComponent<Projectile>();

            if (projectileScript != null)
                projectileScript.Launch(throwDir);
        }
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