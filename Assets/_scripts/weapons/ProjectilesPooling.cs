using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;
using Random = UnityEngine.Random;
using Cysharp.Threading.Tasks;

public class ProjectilesPooling : MonoBehaviour
{
    public TankProjectilesManager projectilesManager; // scriptable object
    public static ProjectilesPooling projectilesPoolingInstance; // this


    public GameObject prefab;
    public GameObject tmpPrefab;
    [SerializeField] private int poolSize;
    public int availableProjectiles;
    public List<GameObject> poolingObject = new List<GameObject>();

    //  public int incrementalDeactivation; // increase when a projectile is used in order to remove it from the list based on the number

    public List<Rigidbody> pooledObjectsRb = new List<Rigidbody>();
    [SerializeField] private Rigidbody tmpRb;

    public float speed;

    
    public Transform parentFind;

    private void Awake()
    {
        speed = projectilesManager.speed;

        projectilesPoolingInstance = this;

        for (int i = 0; i < poolSize; i++)
        {
            tmpPrefab = Instantiate(prefab, transform.position, Quaternion.identity);
            tmpPrefab.SetActive(false);
            poolingObject.Add(tmpPrefab);
            pooledObjectsRb.Add(tmpPrefab.GetComponent<Rigidbody>());
        }

        availableProjectiles = poolingObject.Count;
    }

    private void Update()
    {
         // AdjustPoolingSizeBasedOnDemand(tmpPrefab);
    }

    public void AdjustPoolingSizeBasedOnDemand(GameObject tmpProjectile)
    {
        if (availableProjectiles ==
            5 /*|| availableProjectiles < extraBarrelsManager.extraBarrelInstance.availableBarrels*/)
        {
            for (int i = 0; i < poolSize; i++)
            {
                tmpProjectile = Instantiate(prefab, transform.position, Quaternion.identity);
                tmpProjectile.SetActive(false);
                poolingObject.Add(tmpProjectile);
                pooledObjectsRb.Add(tmpProjectile.GetComponent<Rigidbody>());

                if (poolingObject.Any(null))
                {
                    poolingObject.Remove(tmpProjectile);
                }
            }
        }

        availableProjectiles = poolingObject.Count;
    }

    public void ShootingManager(GameObject projectile, Transform barrelTransform, Rigidbody projectileRb, int positionInList)
    {
        projectile = poolingObject[positionInList];
        projectileRb = pooledObjectsRb[positionInList];
        projectileRb.transform.position = barrelTransform.position;
        projectile.transform.rotation = barrelTransform.rotation;

        projectile.SetActive(true);
        // GameObject shotProjectile = poolingObject[0];

        projectileRb = projectile.GetComponent<Rigidbody>();
    
        projectile.transform.position = barrelTransform.position;
        projectile.transform.rotation = barrelTransform.rotation;
        //projectile.SetActive(true);
        // shotProjectile.transform.position = transform.position;
        // shotProjectile.SetActive(true);
        projectileRb.linearVelocity = barrelTransform.transform.forward * speed;
        poolingObject.RemoveAt(positionInList);
        pooledObjectsRb.RemoveAt(positionInList);
        
       // Debug.Log("my parent is" + projectile);
        
       // AdjustPoolingSizeBasedOnDemand(tmpPrefab);
        availableProjectiles = poolingObject.Count;
        //shotProjectile.transform.rotation = transform.rotation;
        //  incrementalDeactivation++;
    }

    public async UniTask ResetProjectile()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(5));
        GameObject resetProjectile = poolingObject[0];
        Rigidbody resetRb = pooledObjectsRb[0];
        poolingObject.Add(resetProjectile);
        pooledObjectsRb.Add(resetRb);
        resetProjectile.SetActive(false);
        resetProjectile.transform.position = transform.position;
        availableProjectiles = poolingObject.Count;
    }
}