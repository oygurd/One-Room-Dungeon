using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Cysharp.Threading.Tasks;

public class GlobalVolumeCameraEffects : MonoBehaviour
{
    public static GlobalVolumeCameraEffects globalVolumeCameraEffectsInstance { get; private set; }
    Camera mainCam;

    public Volume volume;
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
        if (defaultVolumeProfile.TryGet(out cameraChromaticAberration))
        {
            cameraChromaticAberration.intensity.value = 0f;
        }
    }

    #region gettingHitSection

    public void GettingHit()
    {
        if (defaultVolumeProfile.TryGet(out cameraChromaticAberration))
        {
            cameraChromaticAberration.intensity.value = 0.7f;
            // Debug.Log(cameraChromaticAberration.intensity.value);
        }
    }

    /*public void GettingHitReset()
    {
        float valueTime;
        if (defaultVolumeProfile.TryGet(out cameraChromaticAberration))
        {
            cameraChromaticAberration.intensity.value = 0;
        }
    }*/

    public async UniTask GettingHitReset()
    {
        var duration = 0.5f;
        var elapsed = 0f;

        float chromVal = cameraChromaticAberration.intensity.value;

        float t = 0;
        if (defaultVolumeProfile.TryGet(out cameraChromaticAberration))
        {
            while (t < duration)
            {
                t += Time.deltaTime;
                elapsed += Time.deltaTime;
                float k = Mathf.Clamp01(elapsed / duration) - duration;

                cameraChromaticAberration.intensity.value = Mathf.Lerp(chromVal, 0, k);
                await UniTask.Yield(PlayerLoopTiming.Update);
            }
            cameraChromaticAberration.intensity.value = 0;
        }
    }

    /*public IEnumerator GettingHitSequence()
    {
        GettingHit();
        yield return new WaitForSeconds(0.5f);
        GettingHitReset();
    }*/

    public async UniTask GettingHitSequence()
    {
        GettingHit();
        await UniTask.Delay(TimeSpan.FromSeconds(0.2f));
        GettingHitReset();
    }

    #endregion
}