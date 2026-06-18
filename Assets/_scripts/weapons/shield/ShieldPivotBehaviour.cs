using System;
using System.Collections;
using UnityEngine;

public class ShieldPivotBehaviour : MonoBehaviour
{

    public Transform player;
   // public GameObject[] shields;
    
    public MeleeScriptableObject meleeScriptForTime;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartCD());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
        
    }
    
    IEnumerator StartCD()
    {
        yield return new WaitForSeconds(meleeScriptForTime.time);
        Destroy(gameObject);
    }
}
