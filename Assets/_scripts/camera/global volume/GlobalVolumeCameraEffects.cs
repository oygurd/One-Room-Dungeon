using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GlobalVolumeCameraEffects : MonoBehaviour
{
    public static GlobalVolumeCameraEffects globalVolumeCameraEffectsInstance {get; private set;}
    Camera mainCam;
    
    public Volume  volume;
    ChromaticAberration cameraChromaticAberration;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        mainCam = Camera.main;
        volume = FindAnyObjectByType<Volume>();
        //cameraChromaticAberration = FindAnyObjectByType<ChromaticAberration>();

    }

    #region gettingHitSection

    public void GettingHit()
    {
        if (volume.profile.TryGet<ChromaticAberration>(out cameraChromaticAberration))
        {
            cameraChromaticAberration.intensity.value = 1;
        }
    }

    public void GettingHitReset()
    {
        if (volume.profile.TryGet<ChromaticAberration>(out cameraChromaticAberration))
        {
            cameraChromaticAberration.intensity.value = 0;
        }
    }

    public IEnumerator GettingHitSequence()
    {
        GettingHit();
        yield return new WaitForSeconds(0.5f);
        GettingHitReset();
    }
    #endregion
    
}
