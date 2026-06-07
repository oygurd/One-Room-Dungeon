using Sirenix.OdinInspector;
using UnityEngine;

public class RangedEnemyBehaviourManager : EnemyAttackBehaviour
{
    [Title("Base settings")]
    public GameObject projectilePrefab;
    public float shootInterval = 2f;
    public float shootRange = 8f;   
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
