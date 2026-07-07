using Sirenix.OdinInspector;
using UnityEngine;

public class extraBarrelsManager : SerializedMonoBehaviour
{
    public static extraBarrelsManager extraBarrelInstance;
    public GameObject[] barrels;
    public GameObject[] barrelTips;

    public int availableBarrels;

    private int i;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        extraBarrelInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RevealBarrel()
    {
        if (i != barrelTips.Length) // limit 'i' to the number of extra barrels possible
        {
            barrels[i].SetActive(true);
            availableBarrels++;
            i++;
        }
    }

   
}