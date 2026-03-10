using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public InputHandler inputHandler;
    public Rigidbody2D rb;
    public Collider2D collider;
    public Animator animator;

    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float groundCheckDistance = 0.1f;
    public float glideSpeed = 5f;
    public LayerMask groundLayer;

    [Header("Attack")]
    public float attackDuration = 0.3f;
    public AttackHitbox attackHitbox;
    public float throwDuration = 0.3f;
    public Transform throwOrigin;
    public GameObject projectilePrefab;
    public float slideDuration = 0.5f;
    public float slideSpeed = 8f;

    public PlayerStateMachine StateMachine { get; private set; }

    public IdleState IdleState { get; private set; }
    public RunState RunState { get; private set; }
    public JumpState JumpState { get; private set; }
    public GlideState GlideState { get; private set; }
    public AttackState AttackState { get; private set; }
    public ThrowState ThrowState { get; private set; }
    public DieState DieState { get; private set; }
    public SlideState SlideState { get; private set; }
    public JumpAttackState JumpAttackState { get; private set; }
    public JumpThrowState JumpThrowState { get; private set; }

    private void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (animator == null) animator = GetComponent<Animator>();
        if (collider == null) collider = GetComponent<Collider2D>();
        if (inputHandler == null) inputHandler = GetComponent<InputHandler>();
        if (attackHitbox == null) attackHitbox = GetComponentInChildren<AttackHitbox>();

        StateMachine = new PlayerStateMachine();

        IdleState = new IdleState(StateMachine, this);
        RunState = new RunState(StateMachine, this);
        JumpState = new JumpState(StateMachine, this);
        GlideState = new GlideState(StateMachine, this);
        AttackState = new AttackState(StateMachine, this);
        ThrowState = new ThrowState(StateMachine, this);
        DieState = new DieState(StateMachine, this);
        SlideState = new SlideState(StateMachine, this);
        JumpAttackState = new JumpAttackState(StateMachine, this);
        JumpThrowState = new JumpThrowState(StateMachine, this);
    }

    private void Start()
    {
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.Update();
    }

    private void FixedUpdate()
    {
        StateMachine.FixedUpdate();
        inputHandler?.ClearOneShotFlags();
    }

    public void Die()
    {
        Debug.Log($"PlayerController.Die() called. Current state: {StateMachine.CurrentState?.GetType().Name}");
        
        if (StateMachine.CurrentState != DieState)
        {
            Debug.Log("Transitioning to DieState");
            StateMachine.TransitionToState(DieState);
        }
        else
        {
            Debug.Log("Already in DieState");
        }
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.red);
        return hit.collider != null;
    }

    public void FlipSprite(float moveX)
    {
        if (moveX > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveX < 0) transform.localScale = new Vector3(-1, 1, 1);
    }
}
