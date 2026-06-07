using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;

public class PlayerMovement : SerializedMonoBehaviour
{
    [Title("Stats")]
    public float MovesSpeed;
    
    private Rigidbody rb;
    private InputAction moveAction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("walking");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveValue = moveAction.ReadValue<Vector3>();
        rb.linearVelocity = new Vector3(moveValue.x, 0, moveValue.z) * MovesSpeed;
    }
}
