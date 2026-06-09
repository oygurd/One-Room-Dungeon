using System;
using System.IO.Enumeration;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackBehaviour : MonoBehaviour
{
    public int enemyHp;

    Transform wavesManager;

    /*public void Die()
    {
        wavesManager = GameObject.FindGameObjectWithTag("wavesManager").transform;
        WavesManager wavesmanager = wavesManager.GetComponent<WavesManager>();
        wavesmanager.livingEnemies.RemoveAt(wavesmanager.livingEnemies.Count - 1);
        wavesmanager.enemiesAlive--;
    }*/

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
                Destroy(gameObject);
            }
        }
    }
}