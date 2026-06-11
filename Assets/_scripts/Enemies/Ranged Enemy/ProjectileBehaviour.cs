using System;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    
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
        if (other.gameObject.CompareTag("Player")) //these normal projectiles will have the same tag as the enemy, unless a new enemy with projectiles is made and a scriptable object will be used instead
        {
            Destroy(gameObject);
        }
    }
}
