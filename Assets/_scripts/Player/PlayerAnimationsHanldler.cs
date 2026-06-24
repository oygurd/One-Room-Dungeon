using UnityEngine;

public class PlayerAnimationsHanldler : MonoBehaviour
{
    private Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Shoot()
    {
        animator.SetBool("shooting",true);
    }

    public void Reload()
    {
        animator.SetBool("shooting",false);
    }
}