using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpStatsScriptableObject", menuName = "Scriptable Objects/PowerUpStatsScriptableObject")]
public class PowerUpStatsScriptableObject : ScriptableObject
{
    public int damage;
    public int health;
    public int speed;
}
