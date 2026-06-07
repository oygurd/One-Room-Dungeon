using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackBehaviour : MonoBehaviour
{
    public int enemyHp;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.LowerHp();
            enemyHp -= 1;
            if (enemyHp == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
