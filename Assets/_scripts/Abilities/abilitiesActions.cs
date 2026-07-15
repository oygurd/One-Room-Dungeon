using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public class abilitiesActions : MonoBehaviour
{
    private Image icon;

    private float cooldownNumber;
    
    InputAction qAbility;
    InputAction eAbility;
    InputAction rAbility;

    public AbilityStatsSO abilityStatsSO;

    public bool buttonCanBeUsed;


    public Transform[] mortarSpawnPoints;
    public AnimationCurve fromToRotation;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        qAbility = InputSystem.actions.FindAction("Q Ability");
        eAbility = InputSystem.actions.FindAction("E Ability");
        rAbility = InputSystem.actions.FindAction("R Ability");

        icon = GetComponent<Image>();
        icon.sprite = abilityStatsSO.abilityIcon;
    }

    private void Update()
    {
        if (!buttonCanBeUsed)
        {
            CooldownIconFill();
        }
        if (qAbility.WasPressedThisFrame() && buttonCanBeUsed)
        {
            CameraShakeManager.instance.ZoomLerpOut(60,1);
            ActivateQAbility();
        }
    }

    public void ActivateQAbility()
    {
        DropMortar();
    }

    public void DropMortar()
    {
        GameObject droppedMortar = Instantiate(abilityStatsSO.abilityPrefab,
            mortarSpawnPoints[Random.Range(0, mortarSpawnPoints.Length)].position, Quaternion.identity);

        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        if (groundPlane.Raycast((ray), out float distance))
        {
            Vector3 mousepos = ray.GetPoint(distance);

            //droppedMortar.transform.DOShakeRotation(3, new Vector3(1, 1, 1), 1, 90);
            droppedMortar.transform.DOMove(mousepos, 2).SetEase(Ease.InExpo);
            droppedMortar.transform.DOScale(0.7f, 3).SetEase(Ease.OutExpo);
            
        }
        Cooldown(10);
    }

   public async UniTask Cooldown(float duration)
   {
       buttonCanBeUsed = false;
       cooldownNumber = 0.0f;
       icon.fillAmount = cooldownNumber;
       await UniTask.Delay(TimeSpan.FromSeconds(duration));
       buttonCanBeUsed = true;
   }

   public void CooldownIconFill()
   {
      cooldownNumber += Time.deltaTime;
       icon.fillAmount = Mathf.Clamp01(cooldownNumber / 10);
   }
}