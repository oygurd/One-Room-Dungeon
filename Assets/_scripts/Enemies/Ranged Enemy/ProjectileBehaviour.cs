using System;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) //these normal projectiles will have the same tag as the enemy, unless a new enemy with projectiles is made and a scriptable object will be used instead
        {
            PlayerHealth.instance.LowerHp(1);
            Destroy(gameObject);
        }
    }
}
