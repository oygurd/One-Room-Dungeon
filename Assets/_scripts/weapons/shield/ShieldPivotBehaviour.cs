using System;
using UnityEngine;

public class ShieldPivotBehaviour : MonoBehaviour
{

    public Transform player;
    public GameObject[] shields;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
        
    }
}
