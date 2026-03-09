using UnityEngine;

public class PlayerState : MonoBehaviour
{
    protected PlayerStateMachine stateMachine;
    protected PlayerController player;

    public PlayerState(PlayerStateMachine stateMachine, PlayerController player)
    {
        this.stateMachine = stateMachine;
        this.player = player;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
}
