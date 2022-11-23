using System.Collections;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public LayerMask level;
    [SerializeField] private float dashSpeedX = 30;
    [SerializeField] private float dashSpeedY = 20;
    private BoxCollider2D boxCollider;
    private Vector2 boxColliderSize;
    private float dashCounter;
    [SerializeField] private float dashTimer = 2f;
    private Jump jump;
    public bool canDash ;
    private Rigidbody2D rigidBody;
    private Look look;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        jump = GetComponent<Jump>();
        look = GetComponent<Look>();
        boxCollider = GetComponent<BoxCollider2D>();
        boxColliderSize = boxCollider.bounds.size;
        

    }

    private void FixedUpdate()
    {
        if (IsGrounded() && dashTimer>0)
        {
            canDash = true;
        }
        dashTimer += Time.deltaTime;
    }
    

    public void DoDash(Vector2 mousePosition)
    {
        if (canDash)
        {
            dashTimer = 0;
            canDash = false;
            jump.canJump = false;
            StartCoroutine(StartDash(mousePosition));
        }
    }

    IEnumerator StartDash(Vector2 mousePosition)
    {
        canDash = false;
        rigidBody.velocity = new Vector2(look.FirePoint.right.x * dashSpeedX,look.FirePoint.right.y * dashSpeedY);
        yield return new WaitForSeconds(0.2f);
        jump.canJump = true;
        rigidBody.gravityScale = 6;
    }
    public bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxColliderSize, 0, Vector2.down, 0.1f, level);
    }
    
}

