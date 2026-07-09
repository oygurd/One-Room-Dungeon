using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DustTrailManager : MonoBehaviour
{
    InputAction moveAction;

    private ParticleSystem self;
    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("walking");
        self = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("walking");
        self = GetComponent<ParticleSystem>();
    }

    void FixedUpdate()
    {
        var emission = self.emission;
        if (moveAction.IsPressed())
        {
            emission.enabled = true;
        }
        else
        {
            emission.enabled = false;
        }
    }
}
