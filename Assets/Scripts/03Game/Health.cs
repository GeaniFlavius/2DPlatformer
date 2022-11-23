using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityAction hasDied;
    public UnityAction updatedHealth;
    public Color damageColor;
    public float damageCoolDown;
    [SerializeField]private int startingHealth;
    public int HealthValue {
        get {
            return health;
        }
        set {
            health = value;

            if(value <= 0)
            {
                health = 0;
            }

            if(updatedHealth == null) 
            {
                return;
            }
            
            updatedHealth.Invoke();
        }
    }

    private int health;
    private float damageCoolDownTimer;
    private bool cantGetDamage;
    private SpriteRenderer entitySprite;
    
    private void Start() {
        HealthValue = startingHealth;
        damageCoolDown = 0.1f;
        entitySprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(damageCoolDownTimer > 0) 
        {
            damageCoolDownTimer -= Time.deltaTime;
        }
    }

    public void Reset() {
        HealthValue = startingHealth;
    }

    private void SubtractHealth(Damage damage)
    {
        if  (
                damage == null || 
                damage.inflictor == gameObject || 
                damageCoolDownTimer > 0
            ) 
        {
            return;
        }

        // print(damageCoolDown);
        damageCoolDownTimer = damageCoolDown;
        // print("timer: " + damageCoolDownTimer);
        // print(gameObject.name + " received damage from " + damage.inflictor.name);
        HealthValue -= damage.amount;
        // print(gameObject.name + " now has " + HealthValue);
        FlashEntityRed();

        if(HealthValue <= 0) {
            Die();
        }
    }

    private void AddHealth(HealthBoost healthBoost)
    {
        if(healthBoost == null) 
        {
            return;
        }

        if(HealthValue + healthBoost.amount > startingHealth) 
        {
            HealthValue = startingHealth;
            return;
        }

        HealthValue += healthBoost.amount;
    }

    private void Die() {
        hasDied.Invoke();
    }

    private void FlashEntityRed()
    {
        StartCoroutine(FlashEntityRedProcess());
    }

    private IEnumerator FlashEntityRedProcess()
    {
        entitySprite.color = damageColor;
        yield return new WaitForSeconds(0.1f);
        entitySprite.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Main") 
        {
            return;
        }
        // print("in trigger of " + gameObject.name);
        SubtractHealth(other.GetComponent<Damage>());
        AddHealth(other.GetComponent<HealthBoost>());
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Main") 
        {
            return;
        }
        // print("in collision of " + gameObject.name);
        SubtractHealth(other.gameObject.GetComponent<Damage>());
        AddHealth(other.gameObject.GetComponent<HealthBoost>());
    }
}