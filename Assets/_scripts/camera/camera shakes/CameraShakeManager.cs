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

    private void Awake()
    {
        mainCam = Camera.main;
        instance = this;
        cameraShake = GetComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public async UniTask CamShaker(float strength)
    {
        cameraShake.enabled = true;
        cameraShake.AmplitudeGain = strength;
        await UniTask.Delay(TimeSpan.FromSeconds(0.3f));
        cameraShake.enabled = false;
    }
}