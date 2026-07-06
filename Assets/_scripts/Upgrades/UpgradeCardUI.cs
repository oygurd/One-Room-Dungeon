    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    public class UpgradeCardUI : MonoBehaviour
    {
        public Image self; //self
        public Image icon;
        public TMP_Text nameText;
        public TMP_Text descriptionText;
        public Button selectButton;

        public Sprite specialSprite;

        public GameObject specialUpgradePrefab;
        private UpgradesScriptableObject currentUpgrade;

        public void Setup(UpgradesScriptableObject upgrade)
        {
            currentUpgrade = upgrade;
            self.sprite = upgrade.upgradeBackGround;
            nameText.text = upgrade.upgradeName;
            descriptionText.text = upgrade.upgradeDescription;
            if (upgrade.upgradeIcon != null)
            {
                icon.sprite = upgrade.upgradeIcon;
                icon.preserveAspect = true;
                icon.gameObject.SetActive(true);
            }
            else
            {
                icon.gameObject.SetActive(false);
            }

            if (upgrade.isSpecial) //if an upgrade is special, show its stats and icon as well
            {
                //specialDescription.text = upgrade.specialItem.damage.ToString();
                //specialSprite = upgrade.specialItem.icon;
                specialUpgradePrefab = upgrade.specialItemPrefab;
            }

            selectButton.onClick.RemoveAllListeners();
            selectButton.onClick.AddListener(() => UpgradesManager.instance.SelectUpgrade(currentUpgrade));
            if (upgrade.upgradeIcon != null)
                 selectButton.onClick.AddListener(() => UtilitiesTimerManager.instance.AddUtilityToBarUpgrade(icon, 1));

        }

       
    }