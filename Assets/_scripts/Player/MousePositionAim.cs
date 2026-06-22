using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;
using Unity.Mathematics;

public class MousePositionAim : SerializedMonoBehaviour
{
    private Transform player;

    public Transform showPointer;
    [SerializeField] private Rigidbody playerRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast((ray), out float distance))
        {
            Vector3 mousepos = ray.GetPoint(distance);
            
            Vector3 direction = mousepos - transform.position;
            direction.y = -90;

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction ) * quaternion.Euler(0,55,0);
            }
            showPointer.position = ray.GetPoint(distance);
        }
    }
}