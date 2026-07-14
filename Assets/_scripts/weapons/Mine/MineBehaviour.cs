using System;
using UnityEngine;

public class MineBehaviour : MonoBehaviour
{
    private RaycastHit hit;
    public LayerMask layerMask;

    private Ray ray;

    public ParticleSystem explosion;
    public MeshRenderer mesh;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Collider[] objects =
                Physics.OverlapSphere(transform.position, 5f, layerMask, QueryTriggerInteraction.Collide);
            foreach (var enemyCol in objects)
            {
                enemyCol.TryGetComponent(out EnemyAttackBehaviour enemy);
                enemy.enemyHp -= 3;
            }
            CameraShakeManager.instance.CamShaker(5);
            explosion.Play();
            mesh.enabled = false;
            Destroy(gameObject,2.3f);
        }
    }
}