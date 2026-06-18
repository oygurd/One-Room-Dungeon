using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LaserGatingEnemyBehaviour : SerializedMonoBehaviour
{
    public List<GameObject> FindAllLaserEnemies = new List<GameObject>();

    public LayerMask allyLaserLayer;
    public GameObject body;
    [Title("Base settings")] public GameObject projectilePrefab;
    public float shootInterval = 2f;
    public float LaserRange = 15f;
    public float LimitRnageToPlayer = 10;
    public float rangeFromPlayer;
    public bool selectedByAnotherLaser;
    public bool detectedAnotherLaserEnemy;
    public float speed;
    public bool shootingLaser;
    public bool checkerForAllies;

    [SerializeField] Transform player;

    public Transform[] OtherLaserEnemies;
    public Transform selectedLaserEnemy;
    [Required] [SerializeField] private Transform laserShooter; //assign in the inspector
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

        checkerForAllies = Physics.Raycast(laserShooter.position, laserShooter.right, out laserHitAlly, LaserRange,
            allyLaserLayer);

        FindClosestLaserAlly();
    }


    public void GotoPlayer()
    {
        if (distance > LimitRnageToPlayer)
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

    public void FindClosestLaserAlly()
    {
        OtherLaserEnemies = FindObjectsByType<LaserGatingEnemyBehaviour>(FindObjectsInactive.Exclude);
        if (!detectedAnotherLaserEnemy)
        {
            laserShooter.Rotate(0, 50 * Time.deltaTime, 0);
            if (checkerForAllies)
            {
                detectedAnotherLaserEnemy = true;

                GameObject hitObject = laserHitAlly.collider.gameObject;
                if (hitObject.TryGetComponent(out LaserGatingEnemyBehaviour ally))
                {
                    if (ally.selectedByAnotherLaser) return;

                    ally.selectedByAnotherLaser = true; // sets the bool ON THE HIT ENEMY
                    FindAllLaserEnemies.Add(hitObject);
                    detectedAnotherLaserEnemy = true;

                    

                }
            }
        }
    }


    private void OnDrawGizmos()
    {
        if (!detectedAnotherLaserEnemy)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.green;
        }

        Gizmos.DrawRay(laserShooter.position, laserShooter.right * LaserRange);
    }
}