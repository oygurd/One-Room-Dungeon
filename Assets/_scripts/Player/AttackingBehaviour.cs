using Sirenix.OdinInspector;
using UnityEngine;

public class AttackingBehaviour : SerializedMonoBehaviour
{
    Animator animator;
    
    [HideLabel]
    [ProgressBar(0, 10, r: 1, g: 1, b: 1, Height = 30)]
    [SerializeField] private float animationTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
