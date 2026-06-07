using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class Swordbehaviour : SerializedMonoBehaviour
{
    public Transform player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            Destroy(other.gameObject);
            Debug.Log("new hit");
        }
    }
}
