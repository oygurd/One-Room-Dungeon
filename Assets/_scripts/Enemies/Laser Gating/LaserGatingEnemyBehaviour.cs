using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LaserGatingEnemyBehaviour : SerializedMonoBehaviour
{
    public LaserGatingScannerBehaviour laserGatingScript;
    public LayerMask allyLaserLayer;
    public GameObject body;
    [Title("Base settings")] public GameObject projectilePrefab;
    public float speed;

    public float LimitRnageToPlayer;
    public float rangeFromPlayer;

    public bool shootingLaser;

    public bool movementStop;
    public bool canLookForPlayer;
    [SerializeField] Transform player;

    public Transform selectedLaserEnemy;

    [Required] [SerializeField] private GameObject laserShooter; //assign in the inspector
    public float distance;

    RaycastHit laserHitAlly;
    RaycastCommand raycasthitAlly;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Lure").transform;
        canLookForPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);
        //Shoot();
        if (canLookForPlayer)
        {
            GotoPlayer();
        }
    }


    public void GotoPlayer()
    {
        if (distance > LimitRnageToPlayer && !movementStop && canLookForPlayer)
        {
            transform.LookAt(player);
            // transform.DOLocalMove(player.position, speed);
            transform.position += transform.forward * speed * Time.deltaTime;
            body.transform.right = transform.forward; //make it face the direction of the player
        }
        if (distance <= LimitRnageToPlayer)
        {
            laserGatingScript.startSearching = true;
            movementStop = true;
        }
    }
}