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
    public float wheelRotationSpeed = 90f;
    private float currentWheelRotation = 0;
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
        rb.AddForce(moveValue * MoveSpeed, ForceMode.Force);

        if (moveAction.IsPressed())
        {
            wheelsRotation = new Vector3(moveValue.x, 0, moveValue.z);
            // smoothly lerp wheels to that angle
            Quaternion targetRotation = Quaternion.LookRotation(wheelsRotation);
            wheels.rotation = Quaternion.Lerp(wheels.rotation,targetRotation, 0.2f);
        }

        // wheels.transform.rotation = Quaternion.Lerp(transform.rotation, wheelsRotation, 0.1f);
    }
}