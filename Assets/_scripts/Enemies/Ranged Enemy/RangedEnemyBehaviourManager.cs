using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

public class RangedEnemyBehaviourManager : EnemyAttackBehaviour
{
    [Title("Base settings")]
    public GameObject projectilePrefab;
    public float shootInterval = 2f;
    public float shootRange = 8f;   
    public float speed;
    
    
    [SerializeField] Transform player;

    private float distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);
        GotoPlayer();
    }

    public void GotoPlayer()
    {
        if (distance > shootRange)
        {
            transform.LookAt(player);
            // transform.DOLocalMove(player.position, speed);   
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    public void Shoot()
    {
        
    }

    IEnumerator ShootingDelay()
    {
        yield return new WaitForSeconds(shootInterval);
    }
}
