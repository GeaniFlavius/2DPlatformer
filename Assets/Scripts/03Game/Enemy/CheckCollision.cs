using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class CheckCollision : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Vector2 boxColliderSize = new Vector2(1, 1);
    [SerializeField] private Vector2 rightOffset;
    [SerializeField] private Vector2 leftOffset;
    [SerializeField] private Vector2 upOffset;
    [SerializeField] private Vector2 downOffset;
    [SerializeField] private Vector2 offset;
    [SerializeField] private LayerMask layerMask;
    private bool collisionRight;
    private bool collisionLeft;
    private bool collisionUp;
    private bool collisionDown;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }


    public bool CheckCollisions()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center + (Vector3) offset, boxColliderSize, 0, Vector2.down,0.1f, layerMask);
    }

}