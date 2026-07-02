using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        AdjustPoolingSizeBasedOnDemand(tmpPrefab);
    }

    public void AdjustPoolingSizeBasedOnDemand(GameObject tmpProjectile)
    {
        if (availableProjectiles == 0)
        {
            for (int i = 0; i < poolSize; i++)
            {
                tmpPrefab = Instantiate(prefab, transform.position, Quaternion.identity);
                tmpPrefab.SetActive(false);
                poolingObject.Add(tmpProjectile);
                availableProjectiles = poolingObject.Count;
                pooledObjectsRb.Add(tmpPrefab.GetComponent<Rigidbody>());
            }
        }
    }

    public void ShootingManager()
    { 
        GameObject shotProjectile = poolingObject[0];
        Rigidbody shotRb = pooledObjectsRb[0];
        
        shotProjectile.transform.position = transform.position;
        shotProjectile.SetActive(true);
        shotRb = pooledObjectsRb[0];
        poolingObject.RemoveAt(0);
        pooledObjectsRb.RemoveAt(0);
        availableProjectiles = poolingObject.Count;

        shotRb.linearVelocity = transform.forward * speed;
      //  incrementalDeactivation++;
    }

    public IEnumerator ResetProjectile()
    {
        yield return new WaitForSeconds(5);
        GameObject resetProjectile = poolingObject[0];
        Rigidbody resetRb = pooledObjectsRb[0];
        poolingObject.Add(resetProjectile);
        pooledObjectsRb.Add(resetRb);
        resetProjectile.SetActive(false);
        resetProjectile.transform.position = transform.position;
        availableProjectiles = poolingObject.Count;
    }
}