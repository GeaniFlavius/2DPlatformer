using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Projectiles type;
    public GameObject shooter;

    private const float timeToLive = 2f;
    private float timer;

    private void Update()
    {
        ProjectileLiveDuration();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(shooter == gameObject) { // if it collides with the entity that shot this projectile
            return;
        }
        DestroyProjectile();
    }

    private void DestroyProjectile() {
        BulletManager.Instance.DestroyProjectile(this);
    }

    private void ProjectileLiveDuration()
    {
        if(timer > timeToLive) {
            timer = 0;
            DestroyProjectile();
        }
        timer += Time.deltaTime;
    }
}
