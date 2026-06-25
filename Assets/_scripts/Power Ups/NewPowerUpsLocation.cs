using System.Collections;
using UnityEngine;

public class NewPowerUpsLocation : MonoBehaviour
{
    public GameObject[] PowerUpPrefab;
    
    
    private Camera mainCam;
    public bool castPoint;
    public bool canCast;
    public float sequenceDelay;
    public float randomMarginX, randomMarginY, randomMarginZ;

    public GameObject terrain;

    RaycastHit raycastHit;

    public LayerMask terrainLayer;

    //make the raycast cast at a maximum of 45 degrees
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = Camera.main;
        canCast = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canCast)
            StartCoroutine(Sequencer());
    }

    public void CameraToPlane()
    {
        randomMarginX = Random.Range(-45, 45);
        randomMarginY = Random.Range(-45, 45);
        randomMarginZ = Random.Range(-45, 45);
        
        
        castPoint = Physics.Raycast( mainCam.transform.position + new Vector3(randomMarginX, randomMarginZ , 0), mainCam.transform.forward,
            out raycastHit, Mathf.Infinity, terrainLayer);

        Instantiate(PowerUpPrefab[Random.Range(0, PowerUpPrefab.Length)], raycastHit.point, Quaternion.identity);
        
    }

    IEnumerator Sequencer()
    {
        canCast = false;
        CameraToPlane();
        yield return new WaitForSeconds(sequenceDelay);
        canCast = true;
    }
}