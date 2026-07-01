using System;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesPooling : MonoBehaviour
{
    public  TankProjectilesManager projectilesManager;
    
    public static ProjectilesPooling projectilesPoolingInstance;
    public List<GameObject> pooledProjectile;
    public GameObject objectToPool;
    public int amountToPool;
    
    public float shootingInterval;
    public int damage;
    public float speed;

    public bool canShoot;

    private void Awake()
    {
        projectilesPoolingInstance = this;
        shootingInterval = projectilesManager.shotInterval;
        damage = projectilesManager.damage;
        speed = projectilesManager.speed;
        
    }

    private void Start()
    {
       pooledProjectile = new List<GameObject>();
       GameObject tmp;
       for (int i = 0; i < amountToPool;  i++)
       {
           tmp = Instantiate(objectToPool);
           tmp.SetActive(false);
           pooledProjectile.Add(tmp);
       }
    }

    public GameObject GetPooledProjectile()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledProjectile[i].activeInHierarchy)
            {
                return pooledProjectile[i];
            }
        }
        return null;
    }
}
