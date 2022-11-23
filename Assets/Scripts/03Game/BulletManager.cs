using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance;
    public GameObject onReleaseProjectile;
    public GameObject onHoldProjectile;
    public GameObject onDoubleTapProjectile;

    private Dictionary<Projectiles, GameObject> projectilePrefabs = 
        new Dictionary<Projectiles, GameObject>();

    private Dictionary<Projectiles, Queue<GameObject>> projectiles = 
        new Dictionary<Projectiles, Queue<GameObject>>();
    private Queue<GameObject> releaseProjectiles   = new Queue<GameObject>();
    private Queue<GameObject> holdProjectiles      = new Queue<GameObject>();
    private Queue<GameObject> doubleTapProjectiles = new Queue<GameObject>();

    private void Awake() {
        if(Instance == null) {
            Instance = this;
        }
        else {
            Destroy(this);
        }
    }

    private void Start() {
        InitializeProjectilePrefabDict();
        InitializeProjectileDict();
    }
    
    #region public spawn and destroy
    public GameObject SpawnProjectile(Projectiles type) {
        GameObject projectile;


        if(ProjectileIsEmpty(type)) {
            //print("spawning new");
            projectile = SpawnNewProjectile(type);
        } 
        else {
            //print("getting old");
            projectile = GetProjectileFromQueue(type);
        }

        return projectile;
    }

    public void DestroyProjectile(Projectile projectileToRecycle) {
        AddProjectileToQueue(projectileToRecycle.type, projectileToRecycle.gameObject);
    }
    #endregion
    
    
    #region spawn projectile
    private GameObject SpawnNewProjectile(Projectiles type) {
        GameObject projectilePrefab = GetProjectilePrefab(type);
        GameObject projectile = Instantiate(projectilePrefab, transform, true);

        return projectile;
    }

    private GameObject GetProjectilePrefab(Projectiles type) {
        return projectilePrefabs[type];
    }
    #endregion
    

    #region queue management
    private bool ProjectileIsEmpty(Projectiles type) {
        int count = projectiles[type].Count;
        if(count == 0) {
            return true;
        }
        else {
            return false;
        }
    }

    private void AddProjectileToQueue(Projectiles type, GameObject projectile) {
        projectile.SetActive(false);
        projectiles[type].Enqueue(projectile);
    }

    private GameObject GetProjectileFromQueue(Projectiles type) {
        GameObject projectile = projectiles[type].Dequeue();
        projectile.SetActive(true);
        //print(projectile.activeSelf);
        return projectile;
    } 
    #endregion
    

    #region initialization
    private void InitializeProjectilePrefabDict() {
        projectilePrefabs.Add(Projectiles.OnRelease, onReleaseProjectile);
        projectilePrefabs.Add(Projectiles.OnHold, onHoldProjectile);
        projectilePrefabs.Add(Projectiles.OnDoubletap, onDoubleTapProjectile);
    }

    private void InitializeProjectileDict() {
        projectiles.Add(Projectiles.OnRelease, releaseProjectiles);
        projectiles.Add(Projectiles.OnHold, holdProjectiles);
        projectiles.Add(Projectiles.OnDoubletap, doubleTapProjectiles);
    }
    #endregion
}
