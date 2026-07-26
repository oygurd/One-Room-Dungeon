using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using Image = UnityEngine.UI.Image;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    
    public BasicPlayerStats playerStats;
    
    private float maxHp;
    public float hp;

    public Image hpBar;
    public Transform healthBarHolder;

    public GameObject DeathUI;

    public AudioSource damageSound;
    private void Awake()
    {
        instance = this;
        maxHp = playerStats.hp;
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
            DeathUI.SetActive(true);
            Cursor.visible = true;
        }
    }

    public void LowerHp(int damageTaken)
    {
        damageSound.Play();
        healthBarHolder.transform.DOPunchPosition(Vector3.left + Vector3.up * 10, 0.3f, 1, 1);
        //  hp = Mathf.Lerp(hp, hp -1, 0.5f);
        hp -= damageTaken;
        //  hpBar.fillAmount = Mathf.Lerp(hp, hp -1, 0.5f);

        float fill = Mathf.Clamp01(hp / maxHp);

        //hpBar.fillAmount = Mathf.Lerp(hpBar.fillAmount, fill, 1);
        hpBar.DOFillAmount(fill, 0.5f);


        //  hpBar.fillAmount = Mathf.Clamp01(fill/maxHp);

        // StartCoroutine(GlobalVolumeCameraEffects.globalVolumeCameraEffectsInstance.GettingHitSequence());
        GlobalVolumeCameraEffects.globalVolumeCameraEffectsInstance.GettingHitSequence();
        CameraShakeManager.instance.CamShaker(3, 0.2f);
    }
}