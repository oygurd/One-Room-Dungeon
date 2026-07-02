using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "TankProjectilesManager", menuName = "Scriptable Objects/TankProjectilesManager")]
public class TankProjectilesManager : SerializedScriptableObject
{
    public TankProjectilesManager defaultVal;
    public GameObject prefab;
    public string name;
    public int damage;
    public float speed;
    public float shotInterval;
    [TextArea(4,10)]
    public string description;

}
