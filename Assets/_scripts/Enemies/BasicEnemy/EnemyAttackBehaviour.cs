using System;
using System.IO.Enumeration;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackBehaviour : MonoBehaviour
{
    public int enemyHp;

    Transform wavesManager;

    public void die()
    {
        wavesManager = GameObject.FindGameObjectWithTag("wavesManager").transform;
        WavesManager wavesmanager = wavesManager.GetComponent<WavesManager>();
        wavesmanager.livingEnemies.RemoveAt(wavesmanager.livingEnemies.Count - 1);
        wavesmanager.enemiesAlive--;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            die();
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