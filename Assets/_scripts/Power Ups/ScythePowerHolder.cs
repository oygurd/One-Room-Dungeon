using System;
using UnityEngine;

public class ScythePowerHolder : MonoBehaviour
{
    public GameObject ScythePickup;
    
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
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(ScythePickup, other.transform.position, other.transform.rotation);
            Destroy(gameObject);
        }
    }
}
