using System;
using System.Collections;
using UnityEngine;

public class barrelProjectileInstantiator : MonoBehaviour
{
    public bool barrelsReady;

    private void Awake()
    {
        barrelsReady = false;
        StartCoroutine(SpawnProjectileCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (barrelsReady)
        {
            StartCoroutine(SpawnProjectileCoroutine());
        }
    }

    public void SpawnProjectile()
    {
        GameObject projectile = ProjectilesPooling.projectilesPoolingInstance.GetPooledProjectile();

        if (projectile != null)
        {
            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;
            projectile.SetActive(true);
        }
    }
    
    public IEnumerator SpawnProjectileCoroutine()
    {
        barrelsReady = true;
        yield return new WaitForSeconds(ProjectilesPooling.projectilesPoolingInstance.shootingInterval);
        SpawnProjectile();
        barrelsReady = false;
    }
}
