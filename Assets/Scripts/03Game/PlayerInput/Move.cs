using System;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private int inputRounded;
    private Rigidbody2D rigidBody;
    private Vector2 targetVelocity;
    [SerializeField] [Range(0, 1)] float startingSmooth;
    [SerializeField] [Range(0, 1)] float stoppingSmooth;
    //[SerializeField] [Range(0, 1)] float slidingSmooth;
    [SerializeField] [Range(0, 20)] float runSpeed;
    [SerializeField] [Range(0, 20)] float walkSpeed;
    [SerializeField] [Range(0, 20)] float crawlSpeed;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    public void Run(Vector2 direction)
    {
        DoMove(direction, runSpeed);
    }

    public void Walk(Vector2 direction)
    {
        DoMove(direction, walkSpeed);
    }

    public void Crawl(Vector2 direction)
    {
        DoMove(direction, crawlSpeed);
    }

    private void DoMove(Vector2 direction, float moveSpeed)
    {
        inputRounded = (int) Math.Round(direction.x);
        targetVelocity = new Vector2(inputRounded * moveSpeed, rigidBody.velocity.y);

        if (inputRounded == 0)
        {
            rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, stoppingSmooth);
        }
        else if (inputRounded == 1 || inputRounded == -1)
        {
            rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, startingSmooth);
        }
    }
    public void DroneMove(Vector2 direction, float moveSpeed)
    {
        inputRounded = (int) Math.Round(direction.y);
        targetVelocity = new Vector2(rigidBody.velocity.x, inputRounded * moveSpeed);

        if (inputRounded == 0)
        {
            rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, stoppingSmooth);
        }
        else if (inputRounded == 1 || inputRounded == -1)
        {
            rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, startingSmooth);
        }
    }

    public void DroneMoveTowards(Vector2 playerPosition)
    {
        if (transform.position.x > playerPosition.x ) 
            DoMove(Vector2.left, runSpeed);
        else 
            DoMove(Vector2.right, runSpeed);
        if (transform.position.y > playerPosition.y ) 
            DroneMove(Vector2.down, runSpeed);
        else 
            DroneMove(Vector2.up, runSpeed);
    }
    public void HorizontalMove(Vector2 input)
    {
        inputRounded = (int) Math.Round(input.x);
        targetVelocity = new Vector2(inputRounded * runSpeed, rigidBody.velocity.y);

        if (inputRounded == 0)
        {
            rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, stoppingSmooth);
        }
        else if (inputRounded == 1 || inputRounded == -1)
        {
            rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, startingSmooth);
        }


    }
    public void MoveTowards(Vector2 playerPosition)
    {
        if (transform.position.x > playerPosition.x ) 
            Run(Vector2.left);
        else 
            Run(Vector2.right);
    }
}