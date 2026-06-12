using System;
using System.IO.Enumeration;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackBehaviour : MonoBehaviour
{
    public int enemyHp;

    Transform wavesManager;


    private void OnDestroy()
    {
        WavesManager.Instance.OnEnemyDied(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Die();
            if (collision.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.LowerHp(); // lower PLAYER hp
            }

            enemyHp -= 1;
            if (enemyHp == 0)
            {
                WavesManager.Instance.OnEnemyDied(gameObject);
                Destroy(gameObject);
                
            }
        }
    }
}