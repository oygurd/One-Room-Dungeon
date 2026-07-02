using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class ExtraBarrelProjectile : MonoBehaviour
{
    public bool canShoot;
    
    public TankProjectilesManager projectilesManager;
    public float shootingInterval;
    public int damage;
    public float speed;

    private GameObject projectile;
    private Rigidbody rb;

    private void Awake()
    {
        shootingInterval = projectilesManager.shotInterval;
        damage = projectilesManager.damage;
        speed = projectilesManager.speed;
        canShoot = true;
        
        projectile = ProjectilesPooling.projectilesPoolingInstance.prefab;
        
    }


    public void Shoot()
    {
       
    }

    /*
    IEnumerator ShootingSequencer()
    {
        
    }
    */
        
}