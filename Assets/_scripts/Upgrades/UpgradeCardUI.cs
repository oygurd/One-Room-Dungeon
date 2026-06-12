using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeCardUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public Button selectButton;
    
    private UpgradesScriptableObject currentUpgrade;

    public void Setup(UpgradesScriptableObject upgrade)
    {
        currentUpgrade = upgrade;
        icon.sprite = upgrade.upgradeIcon;
        nameText.text = upgrade.upgradeName;
        descriptionText.text = upgrade.upgradeDescription;
        
        selectButton.onClick.RemoveAllListeners();
        selectButton.onClick.AddListener(() => UpgradesManager.instance.SelectUpgrade(currentUpgrade));
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
