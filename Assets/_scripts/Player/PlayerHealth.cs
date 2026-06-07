using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int hp = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LowerHp()
    {
        hp -= 1;
    }
}
