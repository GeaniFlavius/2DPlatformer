using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Health health;

    private void Start() 
    {
        health = GetComponent<Health>();
        AddListener();
    }

    private void AddListener()
    {
        health.hasDied += DestroyGameObject;
    }

    private void DestroyGameObject() 
    {
        Destroy(gameObject);
    }
}
