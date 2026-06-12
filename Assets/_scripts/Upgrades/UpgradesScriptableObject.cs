using UnityEngine;

[CreateAssetMenu(fileName = "UpgradesScriptableObject", menuName = "Scriptable Objects/UpgradesScriptableObject")]
public class UpgradesScriptableObject : ScriptableObject
{
    [Header("Upgrade Name")]
    public string upgradeName;
    public string upgradeDescription;
    public Sprite upgradeIcon;
    
    [Header("Stats")]
    public int damageBonus;
    public int healthBonus;
    public int speedBonus;
    
    [Header("Specials")]
    public bool isSpecial;
    public string specialName;
    
}
