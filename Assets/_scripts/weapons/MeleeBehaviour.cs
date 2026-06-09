using UnityEngine;

public class MeleeBehaviour : MonoBehaviour
{
    public Transform player;

    public MeleeScriptableObject meleeScriptableObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

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
            enemyHp.enemyHp -= meleeScriptableObject.damage;
            if (enemyHp.enemyHp == 0)
            {
                Destroy(other.gameObject);
            }
            Debug.Log("new hit");
        }
    }
}
