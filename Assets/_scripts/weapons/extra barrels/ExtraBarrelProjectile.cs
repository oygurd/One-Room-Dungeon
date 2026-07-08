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

        projectile = ProjectilesPooling.projectilesPoolingInstance.poolingObject[0];
        self = transform;
    }

    private void Update()
    {
        if (canShoot)
        {
            Debug.Log("I can shooto!");
            canShoot = false;
           //ShootingSequencer();
           StartCoroutine(ShootingSequencerFix());
        }
    }

    public void Shoot()
    {
        ProjectilesPooling.projectilesPoolingInstance.ShootingManager(projectile, self, rb,projectilePositionInList);
       /*var (firedProjectile, firedRb) = ProjectilesPooling.projectilesPoolingInstance.ShootingManagerFixed(self);
       ProjectilesPooling.projectilesPoolingInstance.StartCoroutine(ProjectilesPooling.projectilesPoolingInstance.ResetProjectile(firedProjectile, self, firedRb));*/
    }

    async UniTask ShootingSequencer()
    {
        Shoot();
        ProjectilesPooling.projectilesPoolingInstance.StartCoroutine(
            ProjectilesPooling.projectilesPoolingInstance.ResetProjectile(projectile, self, rb));
        await UniTask.Delay(TimeSpan.FromSeconds(shootingInterval));
        canShoot = true;
    }

    IEnumerator ShootingSequencerFix()
    {
        Shoot();
        /*ProjectilesPooling.projectilesPoolingInstance.StartCoroutine(
            ProjectilesPooling.projectilesPoolingInstance.ResetProjectile(projectile, self, rb));*/
        yield return new WaitForSeconds(shootingInterval);
        canShoot = true;
    }
}