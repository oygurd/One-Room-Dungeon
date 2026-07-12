using System;
using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Random = UnityEngine.Random;

public class UpgradesManager : SerializedMonoBehaviour
{
    public static UpgradesManager instance { get; private set; }

    [Header("All Upgrades")] public List<UpgradesScriptableObject> allUpgrades = new List<UpgradesScriptableObject>();

    public Dictionary<UpgradesScriptableObject, int> allUpgradesDic = new Dictionary<UpgradesScriptableObject, int>();

    [Header("UI")] public GameObject upgradeScreenUI;
    public UpgradeCardUI[] upgradeCards;

    public GameObject[] UItoDisable;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            ShowUpgradeScreen();
        }
    }

    public void ShowUpgradeScreen()
    {

        Time.timeScale = 0;
        upgradeScreenUI.SetActive(true);

        Cursor.visible = true;
        PlayerCursorToMouse cursor = FindFirstObjectByType<PlayerCursorToMouse>();
        cursor.enabled = false;

        for (int i = 0; i < UItoDisable.Length; i++)
        {
            UItoDisable[i].SetActive(false);
        }


        List<UpgradesScriptableObject> choices = GetRandomUpgrades(3);

        for (int i = 0; i < upgradeCards.Length; i++)
        {
            upgradeCards[i].Setup(choices[i]);
        }
    }

    List<UpgradesScriptableObject> GetRandomUpgrades(int count)
    {
        List<UpgradesScriptableObject> pool = new List<UpgradesScriptableObject>(allUpgrades);
        List<UpgradesScriptableObject> choices = new List<UpgradesScriptableObject>();
        
        List<string> chosenName = new List<string>();

         //Dictionary<UpgradesScriptableObject, int> pooldic = new Dictionary<UpgradesScriptableObject, int>();
        //var keys = new List<UpgradesScriptableObject>(pool.Keys);
       
        for (int i = 0; i < count; i++)
        {
            var index = Random.Range(0, pool.Count);
            choices.Add(pool[index]);
            pool.RemoveAt(index); //no duplicates
           // chosenName.Add(pool[index].upgradeName);
            
           
        }
        if (extraBarrelsManager.extraBarrelInstance.availableBarrels == 0) //get rid of the extra barrels card when all 8 are used
        {
            if (chosenName.Contains("Extra barrel"))
            {
                int pos = chosenName.IndexOf("Extra barrel");
                choices.RemoveAt(pos);
            }
        }

        return choices;
    }

    public void HideUpgradeScreen()
    {
        PlayerCursorToMouse cursor = FindFirstObjectByType<PlayerCursorToMouse>();
        cursor.enabled = true;
        Cursor.visible = false;
        upgradeScreenUI.SetActive(false);
        Time.timeScale = 1;
        for (int i = 0; i < UItoDisable.Length; i++)
        {
            UItoDisable[i].SetActive(true);
        }
    }

    public void SelectUpgrade(UpgradesScriptableObject upgrade)
    {
        Applyupgrade(upgrade);
        HideUpgradeScreen();
        WavesManager.Instance.StartCoroutine(WavesManager.Instance.StartNextWave());
    }

    public void Applyupgrade(UpgradesScriptableObject upgrade)
    {
        PlayerHealth playerHealth = FindFirstObjectByType<PlayerHealth>();
        PlayerMovement playerMovement = FindFirstObjectByType<PlayerMovement>();
        // MeleeBehaviour meleeBehaviour = FindFirstObjectByType<MeleeBehaviour>();
        playerShooting playerBaseWeapon = FindFirstObjectByType<playerShooting>();
        //SpecialUpgradeHandler specialUpgradeHandler = FindFirstObjectByType<SpecialUpgradeHandler>();

        if (upgrade.healthBonus != 0)
            playerHealth.hp += (int)upgrade.healthBonus;
        if (upgrade.speedBonus != 0)
            playerMovement.MoveSpeed += (int)upgrade.speedBonus;
        if (upgrade.damageBonus != 0)
            playerBaseWeapon.tankProjectilesManager.damage += (int)upgrade.damageBonus;
        if (upgrade.fireRateBonus != 0)
            playerBaseWeapon.tankProjectilesManager.shotInterval -= (float)upgrade.fireRateBonus;
        if (upgrade.isSpecial && upgrade.specialItemPrefab != null)
            Instantiate(upgrade.specialItemPrefab);
        if (upgrade.isSpecial && upgrade.isExtraBarrels)
        {
            extraBarrelsManager.extraBarrelInstance.RevealBarrel();
            extraBarrelsManager.extraBarrelInstance.availableBarrels -= 1;
            if (extraBarrelsManager.extraBarrelInstance.availableBarrels == 0)
            {
                allUpgrades.RemoveAt(6);
            }
        }
    }
}