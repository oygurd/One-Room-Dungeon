using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradesScriptableObject", menuName = "Scriptable Objects/UpgradesScriptableObject")]
public class UpgradesScriptableObject : SerializedScriptableObject
{
    [Header("Upgrade Name")]
    public string upgradeName;
    [TextArea(4,10)]
    public string upgradeDescription;
    public Sprite upgradeBackGround;
    public Sprite upgradeIcon;
    
    [Header("Stats")]
    public int damageBonus;
    public int healthBonus;
    public int speedBonus;
    public float fireRateBonus;
    public bool hasDuration;
    public float Duration;

    public int numberOfUses;
    
    [Header("Specials")]
    public bool isSpecial;
    public GameObject specialItemPrefab;
    
    public bool isExtraBarrels;
    public bool isJumpAbility;
    public bool isLandMines;
    //public MeleeScriptableObject specialItem; //special upgrades are weapons that can stay for the remainder of the game or for an extended duration more than normal

}
