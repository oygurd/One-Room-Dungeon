using System;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerHealth : MonoBehaviour
{
    [ProgressBar(0, 20, r: 1, g: 1, b: 1, Height = 20)]
    public int hp = 20;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void LowerHp()
    {
        hp -= 1;
        GlobalVolumeCameraEffects.globalVolumeCameraEffectsInstance.GettingHit();
    }

    /*private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            LowerHp();
        }
    }*/
}