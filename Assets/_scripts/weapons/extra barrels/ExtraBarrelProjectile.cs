using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using Cysharp.Threading.Tasks;

public class ExtraBarrelProjectile : MonoBehaviour
{
    public bool canShoot;

    public TankProjectilesManager projectilesManager;
    public float shootingInterval;
    public int damage;
    public float speed;
    public int projectilePositionInList;
    
    public GameObject projectile;
    public Rigidbody rb;

    private Transform self;
    private void Awake()
    {
        shootingInterval = projectilesManager.shotInterval;
        damage = projectilesManager.damage;
        speed = projectilesManager.speed;
        canShoot = true;

        projectile = ProjectilesPooling.projectilesPoolingInstance.prefab;
        self = transform;
    }

    private void Update()
    {
        if (canShoot)
        {
            Debug.Log("I can shooto!");
            canShoot = false;
           ShootingSequencer();
        }
    }

    public void Shoot()
    {
        ProjectilesPooling.projectilesPoolingInstance.ShootingManager(projectile, self, rb,projectilePositionInList);
    }

    async UniTask ShootingSequencer()
    {
        Shoot();
        ProjectilesPooling.projectilesPoolingInstance.ResetProjectile();
        await UniTask.Delay(TimeSpan.FromSeconds(shootingInterval));
        canShoot = true;
    }
    
}