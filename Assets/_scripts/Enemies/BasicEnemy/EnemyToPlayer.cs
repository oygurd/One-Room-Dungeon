using System;
using DG.Tweening;
using UnityEngine;

public class EnemyToPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Lure").transform;
    }

    void Update()
    {
        transform.LookAt(player);
       // transform.DOLocalMove(player.position, speed);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
