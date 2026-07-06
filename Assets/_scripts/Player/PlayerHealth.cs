using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class PlayerHealth : MonoBehaviour
{
    [ProgressBar(0, 20, r: 1, g: 1, b: 1, Height = 20)]
    private float maxHp = 10;
    public float hp;

    public Image hpBar;


    private void Awake()
    {
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

       // hpBar.fillAmount = hp;
    }

    public void LowerHp()
    {
        hp -= 1;
        hpBar.fillAmount = Mathf.Clamp01(hp/maxHp);
       // StartCoroutine(GlobalVolumeCameraEffects.globalVolumeCameraEffectsInstance.GettingHitSequence());
       GlobalVolumeCameraEffects.globalVolumeCameraEffectsInstance.GettingHitSequence();
       CameraShakeManager.instance.CamShaker();
    }

    /*private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            LowerHp();
        }
    }*/
}