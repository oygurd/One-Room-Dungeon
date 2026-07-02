using System;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesPooling : MonoBehaviour
{
    public TankProjectilesManager projectilesManager; // scriptable object
    public static ProjectilesPooling projectilesPoolingInstance; // this


    public GameObject prefab;
    private GameObject tmpPrefab;
    [SerializeField] private int poolSize;
    public int activeProjectiles;
    public List<GameObject> poolingObject = new List<GameObject>();

    private void Awake()
    {
        projectilesPoolingInstance = this;

        for (int i = 0; i < poolSize; i++)
        {
            tmpPrefab = Instantiate(prefab, transform.position, Quaternion.identity);
            tmpPrefab.SetActive(false);
            poolingObject.Add(tmpPrefab);
        }
        activeProjectiles = poolingObject.Count;
    }

    private void Update()
    {
        AdjustPoolingSizeBasedOnDemand();
    }

    public void AdjustPoolingSizeBasedOnDemand()
    {
        if (activeProjectiles == 0)
        {
            for (int i = 0; i < poolSize; i++)
            {
                tmpPrefab = Instantiate(prefab, transform.position, Quaternion.identity);
                tmpPrefab.SetActive(false);
                poolingObject.Add(tmpPrefab);
            }
        }
    }

    /*public GameObject AvailableShot()
    {
        poolingObject.
    }*/
}