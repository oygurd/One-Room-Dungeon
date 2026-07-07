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

    public GameObject projectile;
    public Rigidbody rb;

    private void Awake()
    {
        shootingInterval = projectilesManager.shotInterval;
        damage = projectilesManager.damage;
        speed = projectilesManager.speed;
        canShoot = true;

        projectile = ProjectilesPooling.projectilesPoolingInstance.prefab;
    }

    private void Update()
    {
        if (canShoot)
        {
           ShootingSequencer();
            canShoot = false;
        }
    }

    public void Shoot()
    {
        ProjectilesPooling.projectilesPoolingInstance.ShootingManager(projectile, transform, rb);
    }

    async UniTask ShootingSequencer()
    {
        Shoot();
        ProjectilesPooling.projectilesPoolingInstance.ResetProjectile();
        await UniTask.Delay(TimeSpan.FromSeconds(shootingInterval));
        canShoot = true;
    }
    
}