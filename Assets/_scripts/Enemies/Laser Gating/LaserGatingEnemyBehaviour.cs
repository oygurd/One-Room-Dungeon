using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LaserGatingEnemyBehaviour : SerializedMonoBehaviour
{

    public LayerMask allyLaserLayer;
    public GameObject body;
    [Title("Base settings")] public GameObject projectilePrefab;
    public float speed;

    public float LaserRange = 15f;
    public float LimitRnageToPlayer = 10;
    public float rangeFromPlayer;

    public bool shootingLaser;

    public bool movementStop;
    [SerializeField] Transform player;

    public Transform[] OtherLaserEnemies;
    public Transform selectedLaserEnemy;

    [Required] [SerializeField] private GameObject laserShooter; //assign in the inspector
    private float distance;

    RaycastHit laserHitAlly;
    RaycastCommand raycasthitAlly;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Lure").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);
        Shoot();
        GotoPlayer();

        
    }


    public void GotoPlayer()
    {
        if (distance > LimitRnageToPlayer && !movementStop)
        {
            transform.LookAt(player);
            // transform.DOLocalMove(player.position, speed);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if (distance <= LaserRange && !shootingLaser)
        {
            transform.LookAt(player);
        }
    }
    
}