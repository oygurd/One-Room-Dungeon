using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradesScriptableObject", menuName = "Scriptable Objects/UpgradesScriptableObject")]
public class UpgradesScriptableObject : SerializedScriptableObject
{
    [Header("Upgrade Name")]
    public string upgradeName;
    [TextArea(4,10)]
    public string upgradeDescription;
    public Sprite upgradeIcon;
    
    [Header("Stats")]
    public int damageBonus;
    public int healthBonus;
    public int speedBonus;
    
    [Header("Specials")]
    public bool isSpecial;
    public MeleeScriptableObject specialItem; //special upgrades are weapons that can stay for the remainder of the game or for an extended duration more than normal
    
}
