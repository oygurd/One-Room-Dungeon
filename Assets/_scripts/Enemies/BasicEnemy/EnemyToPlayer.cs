using System;
using DG.Tweening;
using UnityEngine;

public class EnemyToPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;

    public bool hitByShield;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Lure").transform;
    }

    void Update()
    {
        transform.LookAt(player);
        // transform.DOLocalMove(player.position, speed);

        if (!hitByShield)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        
    }
}