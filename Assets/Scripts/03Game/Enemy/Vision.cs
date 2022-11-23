using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Vision : MonoBehaviour
{
    private GameObject target;
    private Collider2D targetCollider;
    private RaycastHit2D raycastHit2D;
    [SerializeField]private LayerMask layerMask;
    private Transform rightVisionPoint;
    private Transform leftVisionPoint;
    public Vector2 lookRight;

    private void Awake()
    {
        target = GameObject.Find("Player");
        targetCollider = target.GetComponent<Collider2D>();
        rightVisionPoint = GetComponentInChildren<Transform>().Find("LookRight");
    }

    private void LateUpdate()
    {
        lookRight = rightVisionPoint.position;
    }

    public bool CannSeePlayer(Vector2 position)
    {
        raycastHit2D = Physics2D.Linecast(transform.position, position, layerMask);
        if (raycastHit2D.collider == targetCollider)
        {
            return true;
        }
        return false;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, lookRight);
    }
}
