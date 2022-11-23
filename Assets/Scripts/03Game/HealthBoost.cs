using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    public int amount;
    public float animationAmplitude;
    public float animationSpeed;
    private Vector3 startingPos;

    private void Start()
    {
        startingPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void Update() 
    {
        Vector3 transformedPos = startingPos;
        transformedPos.y = startingPos.y + 
            Mathf.Sin(Time.time * animationSpeed) * animationAmplitude;
            
        transform.position = transformedPos;
    }
}
