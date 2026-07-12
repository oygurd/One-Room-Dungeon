using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class ShieldPivotBehaviour : MonoBehaviour
{

    public Transform player;
   // public GameObject[] shields;

   public int shieldsRemain;
    public MeleeScriptableObject meleeScriptForTime;

    private void Awake()
    {
        shieldsRemain = 4;
    }

    private void OnDestroy()
    {
       
        if (UtilitiesTimerManager.instance.activeUtilityName.Contains("4 way shield"))
        {
            int pos = UtilitiesTimerManager.instance.activeUtilityName.IndexOf("4 way shield");
            UtilitiesTimerManager.instance.RemoveUtilityFromBarPowerUp(pos);
            
        }
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartCD());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;

        if (shieldsRemain == 0)
        {
            if (UtilitiesTimerManager.instance.activeUtilityName.Contains("4 way shield"))
            {
                int pos = UtilitiesTimerManager.instance.activeUtilityName.IndexOf("4 way shield");
                UtilitiesTimerManager.instance.RemoveUtilityFromBarPowerUp(pos);
            }
            Destroy(gameObject);
        }
    }
    
    IEnumerator StartCD()
    {
        yield return new WaitForSeconds(meleeScriptForTime.time);
        Destroy(gameObject);
    }

    
}
