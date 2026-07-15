using System;
using UnityEngine;
using DG.Tweening;
using Unity.Cinemachine;
using Cysharp.Threading.Tasks;


public class CameraShakeManager : MonoBehaviour
{
    public static CameraShakeManager instance;
    private Camera mainCam;
    private CinemachineCamera cineCam;
    private CinemachineBasicMultiChannelPerlin cameraShake;
    private CinemachineFollow cinemaFollow;

    private void Awake()
    {
        mainCam = Camera.main;
        instance = this;
        cameraShake = GetComponent<CinemachineBasicMultiChannelPerlin>();
        cinemaFollow = GetComponent<CinemachineFollow>();
    }

    public async UniTask CamShaker(float strength,float duration)
    {
        cameraShake.enabled = true;
        cameraShake.AmplitudeGain = strength;
        await UniTask.Delay(TimeSpan.FromSeconds(duration));
        cameraShake.enabled = false;
    }
    
    

    public async UniTask ZoomLerpOut(float distance, float duration)
    {
        float startY = cinemaFollow.FollowOffset.y;
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            cinemaFollow.FollowOffset.y = Mathf.Lerp(startY, distance, Mathf.SmoothStep(0,1, elapsedTime / duration));
            await UniTask.Yield();

        }
    }
    
    public async UniTask ZoomLerpIn( float duration)
    {
        float startY = cinemaFollow.FollowOffset.y;
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            cinemaFollow.FollowOffset.y = Mathf.Lerp(startY, 47.22f, Mathf.SmoothStep(0,1, elapsedTime / duration));
            await UniTask.Yield();

        }
    }
}