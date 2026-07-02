using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Cysharp.Threading.Tasks;
public class GlobalVolumeCameraEffects : MonoBehaviour
{
    public static GlobalVolumeCameraEffects globalVolumeCameraEffectsInstance {get; private set;}
    Camera mainCam;
    
    public Volume  volume;
    VolumeProfile defaultVolumeProfile;
    ChromaticAberration cameraChromaticAberration;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        globalVolumeCameraEffectsInstance = this;
        mainCam = Camera.main;
        volume = FindAnyObjectByType<Volume>();
       // cameraChromaticAberration =  volume.GetComponent<ChromaticAberration>();
        defaultVolumeProfile = volume.sharedProfile;
        cameraChromaticAberration.intensity.value = 0;

    }

    #region gettingHitSection

    public void GettingHit()
    {
        if (defaultVolumeProfile.TryGet(out cameraChromaticAberration))
        {
            cameraChromaticAberration.intensity.value = 1;
          // Debug.Log(cameraChromaticAberration.intensity.value);
        }
    }

    public void GettingHitReset()
    {
        float valueTime;
        if (defaultVolumeProfile.TryGet(out cameraChromaticAberration))
        {
            cameraChromaticAberration.intensity.value = 0;
        }
    }

    /*async UniTask GettingHitReset()
    {
        
    }*/
    public IEnumerator GettingHitSequence()
    {
        GettingHit();
        yield return new WaitForSeconds(0.5f);
        GettingHitReset();
    }
    #endregion
    
}
