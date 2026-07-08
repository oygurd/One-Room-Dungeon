using System;
using UnityEngine;

public class ExtraProjectileBehaviour : MonoBehaviour
{
    public TankProjectilesManager tankProjectilesManager;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
                rb.linearVelocity = Vector3.zero;
                enemy.enemyHp -= tankProjectilesManager.damage;
            }
            gameObject.SetActive(false);
            
            
        }
    }
}
