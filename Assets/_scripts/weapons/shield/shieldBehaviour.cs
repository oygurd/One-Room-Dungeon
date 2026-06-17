using System;
using UnityEngine;
using Sirenix.OdinInspector;
public class shieldBehaviour : SerializedMonoBehaviour
{
    public MeleeScriptableObject meleeScript;
    
    public int damage;
    public int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damage = meleeScript.damage;
        health = meleeScript.health;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyAttackBehaviour enemy = other.gameObject.GetComponent<EnemyAttackBehaviour>();
            EnemyToPlayer enemyMove = other.gameObject.GetComponent<EnemyToPlayer>();
            
            enemy.enemyRb.AddForce(-enemy.transform.forward * meleeScript.knockback, ForceMode.Impulse);
            enemyMove.hitByShield = true;
            health -= 1;

            if (health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
