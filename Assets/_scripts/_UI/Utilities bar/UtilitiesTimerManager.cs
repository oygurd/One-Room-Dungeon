using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UtilitiesTimerManager : MonoBehaviour
{
    public static UtilitiesTimerManager instance;
    public Image instantiationLocation;

    public Image baseImagePrefab;
    public List<Image> activeUtility = new List<Image>();

    public bool isTimeBased;
    public float time;


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

    public void AddUtilityToBarUpgrade(Image upgradeIcon)
    {
        activeUtility.Add(upgradeIcon);
        Image upgradeBackground = Instantiate(baseImagePrefab, instantiationLocation.transform);
        Image upgrade = Instantiate(upgradeIcon, instantiationLocation.transform); 

        upgrade.transform.position = new Vector2(upgrade.rectTransform.position.x + 50 * activeUtility.Count - 400 , upgrade.transform.position.y);
        upgradeBackground.transform.position = new Vector2(upgrade.rectTransform.position.x + 50 * activeUtility.Count - 400 , upgrade.transform.position.y);
        upgradeBackground.transform.position = upgrade.transform.position;
        upgrade.preserveAspect = true;

        upgrade.transform.SetParent(instantiationLocation.transform);
        // upgrade.rectTransform.position = instantiationLocation.transform.position;
        upgrade.rectTransform.localScale = instantiationLocation.transform.localScale / 2.6f;
    }
}