using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackBehaviour : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.LowerHp();
            Destroy(gameObject);
            
        }
    }
}
