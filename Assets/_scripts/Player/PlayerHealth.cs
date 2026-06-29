using System;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [ProgressBar(0, 20, r: 1, g: 1, b: 1, Height = 20)]
    public int hp = 20;

    public TMP_Text hpText;

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        hpText.text = hp.ToString();
    }

    public void LowerHp()
    {
        hp -= 1;
        StartCoroutine(GlobalVolumeCameraEffects.globalVolumeCameraEffectsInstance.GettingHitSequence());
    }

    /*private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            LowerHp();
        }
    }*/
}