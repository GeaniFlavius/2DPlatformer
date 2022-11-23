using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Jump jump;
    private RangeAttack _rangeAttack;
    private Move move;
    private Look look;
    private Flip flip;
    private Vision vision;
    private GameObject player;
    public Vector2 playerPosition;
    public Transform lookAt;
    private Camera camera;

    private void Awake()
    {
        jump = GetComponent<Jump>();
        _rangeAttack = GetComponent<RangeAttack>();
        move = GetComponent<Move>();
        look = GetComponent<Look>();
        flip = GetComponent<Flip>();
        vision = GetComponent<Vision>();
        player = GameObject.Find("Player");
        lookAt = GetComponentInChildren<Transform>().Find("LookAt");
        camera = Camera.main;
    }

    private void Update()
    {
        playerPosition = player.transform.position;
    }

    public void Move(Vector2 direction)
    {
        move.Run(direction);
    }

    public void Shoot()
    {
        _rangeAttack.Shoot(Projectiles.OnRelease);
    }

    public void Look(Vector2 position)
    {
        look.LookDirection(camera.WorldToScreenPoint(position));
    }

    public void Jump()
    {
        jump.DoJump();
    }

    public void Flip(Vector2 position)
    {
        flip.Rotate(camera.WorldToScreenPoint(position));
    }
}
