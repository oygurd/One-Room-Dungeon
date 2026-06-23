using UnityEngine;

public class LaserGatingEnemyLaser : MonoBehaviour
{
    LineRenderer lineRenderer;
    public LaserGatingScannerBehaviour laserGatingScannerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(1, laserGatingScannerScript.hitObject.transform.position);
    }
}
