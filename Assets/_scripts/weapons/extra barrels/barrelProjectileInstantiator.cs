using UnityEngine;

public class barrelProjectileInstantiator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
