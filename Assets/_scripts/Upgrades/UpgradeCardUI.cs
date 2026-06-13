using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeCardUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public Button selectButton;
    
    public TMP_Text specialDescription;
    public Sprite specialSprite;
    
    private UpgradesScriptableObject currentUpgrade;

    public void Setup(UpgradesScriptableObject upgrade)
    {
        currentUpgrade = upgrade;
        icon.sprite = upgrade.upgradeIcon;
        nameText.text = upgrade.upgradeName;
        descriptionText.text = upgrade.upgradeDescription;

        if (upgrade.isSpecial) //if an upgrade is special, show its stats and icon as well
        {
            specialDescription.text = upgrade.specialItem.damage.ToString();
            specialSprite = upgrade.specialItem.icon;
        }
        
        selectButton.onClick.RemoveAllListeners();
        selectButton.onClick.AddListener(() => UpgradesManager.instance.SelectUpgrade(currentUpgrade));
    }
    
    
}
