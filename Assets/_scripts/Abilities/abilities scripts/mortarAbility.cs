using System;
using System.Runtime.InteropServices;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class mortarAbility : MonoBehaviour
{
    public AbilityStatsSO abilityStats;
    
    public LayerMask terrainLayer;

    private bool contact;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contact = Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 0.5f, terrainLayer);
        //contact = Physics.BoxCast(transform.position, -Vector3.up, Vector3.down, transform.localRotation, 0.5f, terrainLayer);
        if (contact)
        {
            TimeStopStrongEffect();
            CameraShakeManager.instance.ZoomLerpIn(1);
            Destroy(gameObject);
        }
    }

    async UniTask TimeStopStrongEffect()
    {
        Time.timeScale = 0;
        await UniTask.Delay(TimeSpan.FromSeconds(0.2f), DelayType.UnscaledDeltaTime);
        CameraShakeManager.instance.CamShaker(6, 1);
        Time.timeScale = 1;
    }

    public void Explode()
    {
        
    }
    
}