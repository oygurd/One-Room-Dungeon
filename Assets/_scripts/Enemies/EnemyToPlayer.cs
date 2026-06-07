using DG.Tweening;
using UnityEngine;

public class EnemyToPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;
    
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        transform.DOLocalMove(player.position, speed);
    }
}
