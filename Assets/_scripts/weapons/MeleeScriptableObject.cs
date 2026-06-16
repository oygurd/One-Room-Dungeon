using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "MeleeScriptableObject", menuName = "Scriptable Objects/MeleeScriptableObject")]
public class MeleeScriptableObject : SerializedScriptableObject
{
    [Header("Info")]
    public string weaponName;
    public Sprite icon;

    [Header("Stats")]
    public int damage;
    public bool hasHealth; //will be used when a weapon is a shield or needs to have hp
    public int health;
    public float knockback;

    [Header("Conditions")]
    public bool timeBased;
    public float time;
}