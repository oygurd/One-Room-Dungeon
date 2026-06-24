using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

public class RangedEnemyBehaviourManager : EnemyAttackBehaviour
{
    [Title("Base settings")] public GameObject projectilePrefab;
    public float shootInterval = 2f;
    public float shootRange = 8f;
    public float projectileSpeed;
    public float speed;
    public bool isShooting;

    [SerializeField] Transform player;

    private float distance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Lure").transform;
    }
    private void OnDestroy()
    {
        WavesManager.Instance.OnEnemyDied(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);
        Shoot();
        GotoPlayer();
        if (enemyHp <= 0)
        {
            // WavesManager.Instance.OnEnemyDied(gameObject);
            Destroy(gameObject);
                
        }
    }
    

    public void GotoPlayer()
    {
        if (distance > shootRange)
        {
            transform.LookAt(player);
            // transform.DOLocalMove(player.position, speed);
            transform.position += transform.forward * speed *  Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if (distance <= shootRange && !isShooting)
        {
            transform.LookAt(player);
            StartCoroutine(ShootingDelay());
        }
    }

    IEnumerator ShootingDelay()
    {
        isShooting = true;
        GameObject shot = Instantiate(projectilePrefab, transform.position, transform.rotation);
        Rigidbody shotRb = shot.GetComponent<Rigidbody>();
        shotRb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
        yield return new WaitForSeconds(shootInterval);
        isShooting = false;
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
            
            enemyHp --;
            /*if (enemyHp <= 0)
            {
                WavesManager.Instance.OnEnemyDied(gameObject);
                Destroy(gameObject);

            }*/
        }
    }
}