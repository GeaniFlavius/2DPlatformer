using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private LayerMask level;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private Vector2 boxColliderSize;
    public float coyoteTimeCounter = 0;
    private float jumpBufferCounter = 0;
    private float jumpBufferTime = 0.1f;
    private float coyoteTime = 0.1f;
    private float jumpForce = 200;
    private float jumpCutMultiplier= 0.2f;
    private float gravityScale =2;
    private float fallGravityMultiplier = 3;
    public bool canJump;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        boxColliderSize = boxCollider.bounds.size;
    }

    private void Update()
    {
        Countdowns();
        ExecuteJump();
    }

    private void FixedUpdate()
    {
        IsGrounded();
        JumpGravity();
    }

    public void DoJump()
    {
        jumpBufferCounter = jumpBufferTime;
    }

    private void ExecuteJump()
    {
        if (coyoteTimeCounter>0 && jumpBufferCounter > 0 && canJump)
        {
            jumpBufferCounter = 0;
            coyoteTimeCounter = 0;
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void JumpGravity()
    {
        if (rigidBody.velocity.y < 0)
        {
            rigidBody.gravityScale = gravityScale * fallGravityMultiplier;
            rigidBody.AddForce(Vector2.down * rigidBody.velocity.y * jumpCutMultiplier, ForceMode2D.Impulse);
        }
    }

    private void Countdowns()
    {
        coyoteTimeCounter -= Time.deltaTime;
        jumpBufferCounter -= Time.deltaTime;
        if (IsGrounded() && coyoteTimeCounter != coyoteTime)
        {
            coyoteTimeCounter = coyoteTime;
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxColliderSize, 0, Vector2.down, 0.1f, level);
    }
}