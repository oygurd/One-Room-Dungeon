using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UtilitiesTimerManager : MonoBehaviour
{
    public static UtilitiesTimerManager instance;//
    
    public Transform instantiationLocation;

    public Image baseImagePrefab;
    public List<Image> activeUtility = new List<Image>();
    public List<GameObject> activeUtilityobject = new List<GameObject>();
    public List<string> activeUtilityName = new List<string>();



    public bool isTimeBased;
    public float duration;


    MeleeScriptableObject melee;
    UpgradesScriptableObject upgrades;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;//
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExecuteSelectin()
    {
    }

    public void AddUtilityToBarPowerUp(Image icon, float duration)  
    {
        
    }

    public void AddUtilityToBarUpgrade(Image upgradeIcon, int amount, bool isTimeBased, float duration, string upgradeName)
    {
        for (int i = 0; i < amount; i++)
        {
            activeUtility.Add(upgradeIcon);
         activeUtilityName.Add(upgradeName);
            
            Image upgrade = Instantiate(upgradeIcon, instantiationLocation.transform);
            upgrade.name = upgradeName;
            TMP_Text count = upgrade.GetComponentInChildren<TMP_Text>();
            
            activeUtilityobject.Add(upgrade.gameObject);

            upgrade.transform.position = new Vector2(upgrade.rectTransform.position.x + 80 * activeUtility.Count - 400, instantiationLocation.transform.position.y);
            
            upgrade.preserveAspect = true;

            upgrade.transform.SetParent(instantiationLocation.transform);
            upgrade.rectTransform.localScale = instantiationLocation.transform.localScale / 2.6f;
        }
    }

    public void RemoveUtilityFromBarPowerUp(int pos)
    {
        GameObject toDestroy = activeUtilityobject[pos];
        Destroy(toDestroy);
        activeUtility.RemoveAt(pos);
        activeUtilityName.RemoveAt(pos);
        activeUtilityobject.RemoveAt(pos);
    }
}