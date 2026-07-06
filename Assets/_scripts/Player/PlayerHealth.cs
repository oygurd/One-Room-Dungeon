using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    
    private float maxHp = 10;
    public float hp;

    public Image hpBar;


    private void Awake()
    {
        instance = this;
        hp = maxHp;
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
        hpBar.fillAmount = Mathf.Clamp01(hp/maxHp);
       // StartCoroutine(GlobalVolumeCameraEffects.globalVolumeCameraEffectsInstance.GettingHitSequence());
       GlobalVolumeCameraEffects.globalVolumeCameraEffectsInstance.GettingHitSequence();
       CameraShakeManager.instance.CamShaker();
    }
}