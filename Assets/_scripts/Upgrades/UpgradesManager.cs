using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;

public class UpgradesManager : SerializedMonoBehaviour
{
    public static UpgradesManager instance { get; private set; }

    [Header("All Upgrades")]
    public UpgradesScriptableObject[] allUpgrades;

    [Header("UI")] public GameObject upgradeScreenUI;
    public UpgradeCardUI[] upgradeCards;

    private void Awake()
    {
        instance = this;
    }

    public void ShowUpgradeScreen()
    {
        Time.timeScale = 0;
        upgradeScreenUI.SetActive(true);


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

        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, pool.Count);
            choices.Add(pool[index]);
            pool.RemoveAt(index); //no duplicates
        }
        return choices;
    }

    public void HideUpgradeScreen()
    {
        upgradeScreenUI.SetActive(false);
        Time.timeScale = 1;
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
        
        if (upgrade.healthBonus != 0)
            playerHealth.hp += (int)upgrade.healthBonus;
        if (upgrade.speedBonus != 0)
            playerMovement.MoveSpeed += (int)upgrade.speedBonus;
        if(upgrade.damageBonus != 0)
            playerBaseWeapon.tankProjectilesManager.damage += (int)upgrade.damageBonus;
        if (upgrade.attackSpeedBonus != 0)
            playerBaseWeapon.tankProjectilesManager.shotInterval -= upgrade.attackSpeedBonus;


    }
}
