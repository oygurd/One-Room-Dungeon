using UnityEngine;
using Sirenix.OdinInspector;
[CreateAssetMenu(fileName = "MeleeScriptableObject", menuName = "Scriptable Objects/MeleeScriptableObject")]
public class MeleeScriptableObject : ScriptableObject
{
    [Header("Info")]
    public string weaponName;
    public Sprite icon;
    
    [Header("Stats")]
    public int damage;
    public float knockback;

    [Header("Conditions")]
    public bool timeBased;
    public float time;
    

}
