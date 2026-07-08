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
      //  AdjustPoolingSizeBasedOnDemand(tmpPrefab);
    }

    public void AdjustPoolingSizeBasedOnDemand(GameObject tmpProjectile)
    {
        if (availableProjectiles <= 16)
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

    public void ShootingManager(GameObject projectile, Transform barrelTransform, Rigidbody projectileRb,
        int positionInList)
    {
        projectile = poolingObject[positionInList];
        projectileRb = pooledObjectsRb[positionInList];
        projectileRb.transform.position = barrelTransform.position;
        projectile.transform.rotation = barrelTransform.rotation;

        projectile.SetActive(true);

        projectileRb = projectile.GetComponent<Rigidbody>();

        projectile.transform.position = barrelTransform.position;
        projectile.transform.rotation = barrelTransform.rotation;

        projectileRb.linearVelocity = barrelTransform.transform.forward * speed;
        poolingObject.RemoveAt(positionInList);
        pooledObjectsRb.RemoveAt(positionInList);

        StartCoroutine(ResetProjectile(projectile, barrelTransform, projectileRb));

        availableProjectiles = poolingObject.Count;
    }

    public (GameObject, Rigidbody) ShootingManagerFixed(Transform barrelTransform) // no use but keep it to learn from
    {
        int index = poolingObject.Count - 1;
        GameObject projectile = poolingObject[index];
        Rigidbody projectileRb = pooledObjectsRb[index];

        projectileRb.transform.position = barrelTransform.position;
        projectile.transform.position = barrelTransform.position;
        projectile.transform.rotation = barrelTransform.rotation;

        projectile.SetActive(true);
        projectileRb.linearVelocity = barrelTransform.transform.forward * speed;

        poolingObject.RemoveAt(index);
        pooledObjectsRb.RemoveAt(index);
        availableProjectiles = poolingObject.Count;

        return (projectile, projectileRb);
    }

    public IEnumerator ResetProjectile(GameObject projectile, Transform barrelTransform, Rigidbody projectileRb)
    {
        yield return new WaitForSeconds(5);
        poolingObject.Add(projectile);
        pooledObjectsRb.Add(projectileRb);
        projectile.SetActive(false);
        projectile.transform.position = barrelTransform.position;
        availableProjectiles = poolingObject.Count;
        // StopCoroutine(ResetProjectile(projectile, barrelTransform, projectileRb));
    }
}