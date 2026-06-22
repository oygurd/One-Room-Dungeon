using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Sirenix.OdinInspector;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LaserGatingScannerBehaviour : SerializedMonoBehaviour
{
    public LaserGatingEnemyBehaviour mainLaserGatingScript;
    public List<GameObject> FindAllLaserEnemies = new List<GameObject>();
    public LaserGatingEnemyAnimController animController;

    public LayerMask allyLaserLayer;
    [Title("Base settings")] private Collider self;

    public Transform mainBody;

    public float shootInterval = 2f;
    public float LaserRange = 15f;
    public float distance;
    public float distanceFromAlly;
    public float minimumDistanceFromAlly;

    [TitleGroup("Bools")] [GUIColor("#27F5F2")]
    public bool startSearching;

    [GUIColor("#FCF408")] public bool selectedByAnotherLaser;
    [GUIColor("#FC0808")] public bool detectedAnotherLaserEnemy;
    [GUIColor("#3DFC08")] public bool checkerForAllies;

    public bool rayIsRed;

    public bool shootingLaser;


    RaycastHit laserHitAlly;
    RaycastCommand raycasthitAlly;

    public GameObject hitObject;
    private void Start()
    {
        self = GetComponent<Collider>();
        animController.Moving = true;
    }

    private void Update()
    {
        if (startSearching)
        {
            animController.Moving = false;
            animController.Searching = true;
            checkerForAllies = Physics.Raycast(transform.position, transform.up,
                out laserHitAlly, LaserRange,
                allyLaserLayer);
            LaserRange = 24;
        }


        if (!rayIsRed && startSearching)
        {
            FindClosestLaserAlly();
        }

        distance = mainLaserGatingScript.distance;
    }

    public void FindClosestLaserAlly()
    {
        if (!detectedAnotherLaserEnemy)
        {
            //transform.Rotate(0, 50 * Time.deltaTime, 0);
            if (checkerForAllies)
            {
                detectedAnotherLaserEnemy = true;
                mainLaserGatingScript.movementStop = true;

                 hitObject = laserHitAlly.collider.gameObject;
                if (hitObject.TryGetComponent(out LaserGatingScannerBehaviour ally))
                {
                    animController.Searching = false;
                    mainBody.rotation = Quaternion.FromToRotation(-Vector3.right,
                        hitObject.transform.position - transform.position);
                    animController.Shooting = true;
                    ally.selectedByAnotherLaser = true; // sets the bool ON THE HIT ENEMY
                    FindAllLaserEnemies.Add(hitObject);
                    detectedAnotherLaserEnemy = true;
                    ally.selectedByAnotherLaser = true;
                    //transform.position = new Vector3(0, 0, 0);
                    self.enabled = false;
                    ally.self.enabled = false;
                    LaserGatingEnemyBehaviour allybody = ally.GetComponentInParent<LaserGatingEnemyBehaviour>();
                    allybody.movementStop = true;
                    rayIsRed = true;
                    distanceFromAlly = laserHitAlly.distance;
                }
            }
        }
    }

    public void ChangeAllyDistance()
    {
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

        if (!startSearching)
        {
            Gizmos.color = Color.cyan;
        }

        Gizmos.DrawRay(transform.position, transform.up * LaserRange);
    }
}