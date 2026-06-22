using System;
using UnityEngine;

public class LaserGatingEnemyAnimController : MonoBehaviour
{
    public Animator animator;
   [SerializeField] private bool isMoving;
   [SerializeField] private bool isSearching;
   [SerializeField] private bool isShooting;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    //'CORE HOLDER' IS THE SCANNER AS WELL!

    public void Idle()
    {
        isMoving = false;
        isShooting = false;
        isSearching = false;
        Debug.Log("im idle!");
    }

    
    public bool Moving
    {
        get => isMoving;
        set
        {
            isMoving = value;
            animator.SetBool("isMoving", value);
            Debug.Log("im moving!");
        }
    }

    public bool Shooting
    {
        get => isShooting;
        set
        {
            isShooting  = value;
            animator.SetBool("isShooting", value);
            Debug.Log("im moving!");
        }
    }

    public bool Searching
    {
        get => isSearching;
        set
        {
            isSearching = value;
            animator.SetBool("isSearching", value);
            Debug.Log("im searching!");
        }
    }
}