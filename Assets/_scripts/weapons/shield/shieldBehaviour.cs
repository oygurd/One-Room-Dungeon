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
            
            enemy.enemyRb.AddRelativeForce(-enemy.transform.forward * 20, ForceMode.Impulse);
            health -= 1;

            if (health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
