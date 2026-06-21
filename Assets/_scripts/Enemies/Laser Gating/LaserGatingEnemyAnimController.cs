using UnityEngine;

public class LaserGatingEnemyAnimController : MonoBehaviour
{
    public Animator animator;
    public bool isMoving;
    public bool isSearching;
    public bool isShooting;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    //CORE HOLDER IS THE SCANNER AS WELL!

    // Update is called once per frame
    void Update()
    {
    }
}