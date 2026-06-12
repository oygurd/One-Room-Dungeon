using System.Collections;
using UnityEngine;

public class MeleeBehaviour : MonoBehaviour
{
    public Transform player;
    public int damage;
    public MeleeScriptableObject meleeScriptableObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (meleeScriptableObject.timeBased)
        {
            StartCoroutine(StartCountDown());
        }
        damage = meleeScriptableObject.damage;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyAttackBehaviour enemyHp = other.gameObject.GetComponent<EnemyAttackBehaviour>();
            enemyHp.enemyHp -= damage;
            if (enemyHp.enemyHp == 0)
            {
                Destroy(other.gameObject);
            }

            Debug.Log("new hit");
        }
    }

    IEnumerator StartCountDown()
    {
        yield return new WaitForSeconds(meleeScriptableObject.time);
        Destroy(gameObject);
    }
}