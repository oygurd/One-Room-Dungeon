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

    public Transform wheels;
    public Vector3 wheelsRotation;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("walking");
    }

    private void Update()
    {
        moveValue = moveAction.ReadValue<Vector3>().normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        rb.AddForce(moveValue * MoveSpeed, ForceMode.Force);


        wheelsRotation += moveValue;
       // wheels.transform.rotation = Quaternion.Lerp(transform.rotation, wheelsRotation, 0.1f);
    }
}