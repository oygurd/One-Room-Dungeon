using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class EnemyToPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;
    [SerializeField] private Rigidbody rb;

    public bool hitByShield;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Lure").transform;
    }

    void FixedUpdate()
    {
        transform.LookAt(player);
        // transform.DOLocalMove(player.position, speed);

        if (!hitByShield)
        {
            rb.AddForce(transform.forward * speed,  ForceMode.Force);
            //transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (hitByShield)
        {
            StartCoroutine(StartCount());
        }
        
    }


    IEnumerator StartCount()
    {
        yield return new WaitForSeconds(2);
        hitByShield = false;
    }
}