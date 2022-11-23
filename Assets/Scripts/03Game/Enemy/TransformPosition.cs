using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPosition : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] [Range(0, 10)] public float rotateSpeed;
    [SerializeField][Range(0, 10)] public float radius;
    private Vector2 center;
    private float angle;
    private void Start()
    {
        center = transform.position;
        rigidbody2D = GetComponentInParent<Rigidbody2D>();
    }
    private void Update()
    {
        center += rigidbody2D.velocity * Time.deltaTime;
        angle += rotateSpeed * Time.deltaTime;
        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = center + offset;
    }
}
