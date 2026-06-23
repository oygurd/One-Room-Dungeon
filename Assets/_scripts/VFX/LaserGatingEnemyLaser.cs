using UnityEngine;

public class LaserGatingEnemyLaser : MonoBehaviour
{
    LineRenderer lineRenderer;

    public LaserGatingScannerBehaviour laserGatingScannerScript;

    public GameObject ally;
    bool laserGating = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ally = laserGatingScannerScript.hitObject.gameObject;
        if (laserGating)
        {
            lineRenderer.SetPosition(1, new Vector3(-laserGatingScannerScript.distanceFromAlly / 100,0,0));
        }
        
    }
}