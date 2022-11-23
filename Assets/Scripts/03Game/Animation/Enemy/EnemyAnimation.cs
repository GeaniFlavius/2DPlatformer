using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody;
    private int idle;
    private int run;
    private int attack1;
    private int attack2;
    private int hit;
    private int death;
    private int walk;
    private int teleport;
    private int slam;
    private MeleeAttack meleeAttack;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        idle = Animator.StringToHash( "Idle");
        run = Animator.StringToHash( "Run");
        attack1 = Animator.StringToHash( "Attack1");
        attack2 = Animator.StringToHash( "Attack2");
        hit = Animator.StringToHash( "Hit");
        death = Animator.StringToHash( "Death");
        walk = Animator.StringToHash( "Walk");
        teleport = Animator.StringToHash( "Teleport");
        slam = Animator.StringToHash( "Slam");
        meleeAttack = GetComponent<MeleeAttack>();
    }

    private void Update()
    {
        AnimateIdle(rigidBody.velocity.x == 0);
        AnimateRun(rigidBody.velocity.x > 0);
        //AnimateAttack1(meleeAttack.isAttacking);
        //AnimateAttack2();
        //AnimateHit();
        //AnimateDeath();
        //AnimateWalk();
        //AnimateTeleport();
        //AnimateSlam();
    }

    public void AnimateIdle(bool state)
    {
        animator.SetBool(idle, state);
    }
    
    public void AnimateRun(bool state)
    {
        animator.SetBool(run, state);
    }
    public void AnimateAttack1(bool state)
    {
        animator.SetBool(attack1, state);
    }
    public void AnimateAttack2(bool state)
    {
        animator.SetBool(attack2, state);
    }
    public void AnimateHit(bool state)
    {
        animator.SetBool(hit, state);
    }
    public void AnimateDeath(bool state)
    {
        animator.SetBool(death, state);
    }
    public void AnimateWalk(bool state)
    {
        animator.SetBool(walk, state);
    }
    public void AnimateTeleport(bool state)
    {
        animator.SetBool(teleport, state);
    }
    public void AnimateSlam(bool state)
    {
        animator.SetBool(slam, state);
    }
}
