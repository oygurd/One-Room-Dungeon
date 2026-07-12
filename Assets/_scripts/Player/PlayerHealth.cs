using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
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
        //  hp = Mathf.Lerp(hp, hp -1, 0.5f);
        hp -= 1;
        //  hpBar.fillAmount = Mathf.Lerp(hp, hp -1, 0.5f);

        float fill = Mathf.Clamp01(hp / maxHp);

        //hpBar.fillAmount = Mathf.Lerp(hpBar.fillAmount, fill, 1);
        hpBar.DOFillAmount(fill, 0.5f);
        

        //  hpBar.fillAmount = Mathf.Clamp01(fill/maxHp);

        // StartCoroutine(GlobalVolumeCameraEffects.globalVolumeCameraEffectsInstance.GettingHitSequence());
        GlobalVolumeCameraEffects.globalVolumeCameraEffectsInstance.GettingHitSequence();
        CameraShakeManager.instance.CamShaker();
    }
}