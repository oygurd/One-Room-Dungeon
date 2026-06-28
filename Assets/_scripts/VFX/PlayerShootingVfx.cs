using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

[ExecuteInEditMode]
public class PlayerShootingVfx : MonoBehaviour
{
    public static PlayerShootingVfx playerShootingVfxInstance {get; private set;}
    public GameObject vfxPrefab;
    public VisualEffect  vfxEffect;

     static readonly ExposedProperty startEvent = "OnPlay";
     static readonly ExposedProperty endEvent = "OnEnd";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerShootingVfxInstance  = this;
    }
    
    public void EnableShootVFX()
    {
       vfxEffect.SendEvent(startEvent);
    }

    public void DisableShootingVFX()
    {
        vfxEffect.SendEvent(endEvent);
    }
}
