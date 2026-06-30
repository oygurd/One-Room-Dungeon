using Sirenix.OdinInspector;
using UnityEngine;

public class extraBarrelsManager : SerializedMonoBehaviour
{
    public static extraBarrelsManager extraBarrelInstance;
    public GameObject[] barrels;
    public GameObject[] barrelTips;

    public int i;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        extraBarrelInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void
        RevealBarrel() //make a method that detracts the 'h' by 1 when a barrel's time is ending (if the barrels will have time limit on them)
    {
        i++;
        barrels[i].SetActive(true);

    }
}
