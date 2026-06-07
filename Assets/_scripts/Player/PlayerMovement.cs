using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;

public class PlayerMovement : SerializedMonoBehaviour
{
    [Title("Stats")] public float MoveSpeed;

    private Rigidbody rb;
    private InputAction moveAction;

    private Vector3 moveValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("walking");
    }

    private void Update()
    {
        moveValue = moveAction.ReadValue<Vector3>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //  Vector3 moveValue = moveAction.ReadValue<Vector3>();
        //Vector3 move = new Vector3(moveValue.x, 0f, moveValue.z).normalized;

        rb.AddForce(moveValue * MoveSpeed, ForceMode.Force);
    }
}