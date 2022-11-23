using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public Sprite[] healthStates;

    private Health health;
    private SpriteRenderer healthSprite;
    private void Start()
    {
        health = transform.parent.GetComponent<Health>();
        healthSprite = GetComponent<SpriteRenderer>();
        health.updatedHealth += UpdateHealthSprite;
    }

    private void UpdateHealthSprite() 
    {
        if(health.HealthValue - 1 < 0) 
        {
            return;
        }

        healthSprite.sprite = healthStates[health.HealthValue -1];
    }
}
