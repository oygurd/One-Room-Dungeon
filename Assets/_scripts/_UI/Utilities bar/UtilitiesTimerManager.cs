using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UtilitiesTimerManager : MonoBehaviour
{
    public static UtilitiesTimerManager instance;
    public Transform instantiationLocation;

    public Image baseImagePrefab;
    public List<Image> activeUtility = new List<Image>();

    public bool isTimeBased;
    public float duration;


    MeleeScriptableObject melee;
    UpgradesScriptableObject upgrades;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
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

    public void AddUtilityToBarUpgrade(Image upgradeIcon, int amount, bool isTimeBased, float duration)
    {
        for (int i = 0; i < amount; i++)
        {
            activeUtility.Add(upgradeIcon);
         
            Image upgrade = Instantiate(upgradeIcon, instantiationLocation.transform);

            upgrade.transform.position = new Vector2(upgrade.rectTransform.position.x + 80 * activeUtility.Count - 400, instantiationLocation.transform.position.y);
            
            upgrade.preserveAspect = true;

            upgrade.transform.SetParent(instantiationLocation.transform);
            upgrade.rectTransform.localScale = instantiationLocation.transform.localScale / 2.6f;
        }
    }
}