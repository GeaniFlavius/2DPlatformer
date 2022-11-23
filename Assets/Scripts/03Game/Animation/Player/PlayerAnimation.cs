using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody;
    private InputAction movement;
    private Vector2 inputVector;
    //Animation Id's
    private int rising;
    private int falling;
    private int moving;
    private int idle;
    private int runBackwards;
    //bad code
    public float xPointFromScreen;
    public float xPointFromWorld;
    private Flip flip;
    //end bad code
    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerController>().movementInput;
        //bad code
        flip = GetComponent<Flip>();
        //end bad code
        rising = Animator.StringToHash( "Rising");
        falling = Animator.StringToHash( "Falling");
        moving = Animator.StringToHash("Moving");
        idle = Animator.StringToHash(("Idle"));
        runBackwards = Animator.StringToHash("RunBackwards");
    }

    private void FixedUpdate()
    {
        //bad code
        xPointFromScreen = flip.xPointFromScreen;
        xPointFromWorld = flip.xPointFromWorld;
        //end bad code
        inputVector = movement.ReadValue<Vector2>();
    }

    private void Update()
    {
        AnimateMove(xPointFromScreen>xPointFromWorld && inputVector.x ==1||xPointFromScreen<xPointFromWorld && inputVector.x ==-1);
        RisingJump(rigidBody.velocity.y > 0.1f);
        Falling(rigidBody.velocity.y < 0);
        AnimateIdle(rigidBody.velocity.y == 0);
        AnimateRunBackwards(xPointFromScreen<xPointFromWorld && inputVector.x ==1||xPointFromScreen>xPointFromWorld && inputVector.x ==-1);
        
    }
    
    public void RisingJump(bool state)
    {
        animator.SetBool(rising,state);
    }
    
    public void Falling(bool state)
    {
        animator.SetBool(falling,state);
    }
    
    
    public void AnimateMove(bool state)
    {
        animator.SetBool(moving,state);
    }

    public void AnimateIdle(bool state)
    {
        animator.SetBool(idle,state);
    }

    public void AnimateRunBackwards(bool state)
    {
        animator.SetBool(runBackwards,state);
    }
    public void AnimateShoot()
    {
        
    }

    public void AnimateMoveBackwards(bool state)
    {

    }
}
