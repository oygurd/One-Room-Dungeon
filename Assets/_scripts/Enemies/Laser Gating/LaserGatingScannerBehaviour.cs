using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LaserGatingScannerBehaviour : SerializedMonoBehaviour
{
    public LaserGatingEnemyBehaviour mainLaserGatingScript;
    public List<GameObject> FindAllLaserEnemies = new List<GameObject>();

    public LayerMask allyLaserLayer;
    [Title("Base settings")] public GameObject projectilePrefab;
    private Collider self;
    public float shootInterval = 2f;
    public float LaserRange = 15f;

    public bool selectedByAnotherLaser;
    public bool detectedAnotherLaserEnemy;
    public bool checkerForAllies;
    public bool rayIsRed;

    public bool shootingLaser;

    private float distance;

    RaycastHit laserHitAlly;
    RaycastCommand raycasthitAlly;

    private void Start()
    {
        self = GetComponent<Collider>();
    }

    private void Update()
    {
        checkerForAllies = Physics.Raycast(transform.position, transform.right,
            out laserHitAlly, LaserRange,
            allyLaserLayer);

        if (!rayIsRed)
        {
            FindClosestLaserAlly();
        }
    }

    public void
        FindClosestLaserAlly() // make the scanner head go down when found an ally, changing to the lethal laser with another object
    {
        if (!detectedAnotherLaserEnemy)
        {
            transform.Rotate(0, 50 * Time.deltaTime, 0);
            if (checkerForAllies)
            {
                detectedAnotherLaserEnemy = true;
                mainLaserGatingScript.movementStop = true;

                GameObject hitObject = laserHitAlly.collider.gameObject;
                if (hitObject.TryGetComponent(out LaserGatingScannerBehaviour ally))
                {
                    ally.selectedByAnotherLaser = true; // sets the bool ON THE HIT ENEMY
                    FindAllLaserEnemies.Add(hitObject);
                    detectedAnotherLaserEnemy = true;
                    //transform.position = new Vector3(0, 0, 0);
                    self.enabled = false;
                    rayIsRed = true;
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
            Gizmos.color = Color.red;
        }

        Gizmos.DrawRay(transform.position, transform.right * LaserRange);
    }
}