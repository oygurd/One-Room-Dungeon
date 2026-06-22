using UnityEngine;

public class LaserGatingEnemyLaser : LaserGatingScannerBehaviour
{
    LineRenderer lineRenderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(1, hitObject.transform.position);
    }
}
