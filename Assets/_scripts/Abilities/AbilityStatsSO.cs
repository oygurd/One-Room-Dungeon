using UnityEngine;

[CreateAssetMenu(fileName = "AbilityStatsSO", menuName = "Scriptable Objects/AbilityStatsSO")]
public class AbilityStatsSO : ScriptableObject
{
    public string abilityName;
    public string description;
    public float abilityCooldown;
    public Sprite abilityIcon;
    public GameObject abilityPrefab;
    //public string abilityButton;
    public float abilityDamage;
}
