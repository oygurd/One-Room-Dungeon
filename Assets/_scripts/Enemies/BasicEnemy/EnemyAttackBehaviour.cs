using System;
using System.IO.Enumeration;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackBehaviour : MonoBehaviour
{

    public EnemiesStatsSO enemyStats;
    public int enemyHp;
    public Rigidbody enemyRb;

    public ParticleSystem death;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyHp = enemyStats.health;

        enemyStats.damage = 1;
    }

    private void OnDestroy()
    {
        WavesManager.Instance.OnEnemyDied(gameObject);
    }

    private void Update()
    {
        if (enemyHp <= 0)
        {
            // WavesManager.Instance.OnEnemyDied(gameObject);
            death.gameObject.transform.SetParent(null);
            death.Play();
            gameObject.SetActive(false);
            Destroy(gameObject, 1);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Die();
            if (collision.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.LowerHp(enemyStats.damage); // lower PLAYER hp
            }
            enemyHp--;
        }
    }
}