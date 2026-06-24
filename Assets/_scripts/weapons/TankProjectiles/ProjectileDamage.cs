using System;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public TankProjectilesManager tankProjectilesManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
           if (other.TryGetComponent(out EnemyAttackBehaviour enemy))
           {
               enemy.enemyHp -= tankProjectilesManager.damage;
           }
           Destroy(gameObject);
        }
    }
}
