
using UnityEngine;
using Random = UnityEngine.Random;

public class RangeAttack : MonoBehaviour
{
    [SerializeField]private float bulletSpeed = 50;
    private Look look;
    [SerializeField]private float minimumShootAngle = -0.05f;
    [SerializeField]private float maximumShootAngle = 0.05f;
    private Vector3 direction;
    [SerializeField]private float bulletsPerSecond = 1f;
    private float bulletTimer;
    private void Awake()
    {
        look = GetComponent<Look>();
        bulletTimer = bulletsPerSecond;
    }

    private void Update()
    { 
        bulletTimer -= Time.deltaTime;
    }

    public void ShootOnRelease()
    {
        Shoot(Projectiles.OnRelease);
    }

    public void ShootOnHold()
    {
        Shoot(Projectiles.OnHold);
    }

    public void ShootOnDoubleTap()
    {
        // TODO does not work
        Shoot(Projectiles.OnDoubletap);
    }

    public void Shoot(Projectiles type)
    {
        if (CanAttack())
        {
            GameObject bulletClone = BulletManager.Instance.SpawnProjectile(type);

            Projectile projectile = bulletClone.GetComponent<Projectile>();
            projectile.shooter = gameObject;
            Damage damage = bulletClone.GetComponent<Damage>();
            damage.inflictor = gameObject;
            print(gameObject.name + " has shot");

            bulletClone.transform.position = look.FirePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, look.Angle);
            //TODO implement accuracy based on number of shots fired and player state(running standing)
            direction = look.FirePoint.right + new Vector3(0, Random.Range(minimumShootAngle, maximumShootAngle));
            bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
        else return;
    }
    private bool CanAttack()
    {
        if (bulletTimer < 0)
        {
            bulletTimer = bulletsPerSecond;
            return true;
        }
        return false;
    }
}