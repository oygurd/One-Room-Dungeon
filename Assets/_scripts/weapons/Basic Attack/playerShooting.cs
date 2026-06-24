using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class playerShooting : MonoBehaviour
{
    public Scrollbar shotIntervalIndicator;
    [SerializeField] private InputActionAsset playerInputActionAsset;
    public InputAction shootingAttack;
    
    public bool canShoot = true;
    public float elapsedTime;
    public TankProjectilesManager tankProjectilesManager;

    public Transform nozzle;

    public PlayerAnimationsHanldler playerAnims;
    private void OnEnable()
    {
        playerInputActionAsset.FindAction("Attack").Enable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // shotIntervalIndicator.size = 0;
        shootingAttack = InputSystem.actions.FindAction("Attack");
        shotIntervalIndicator.size = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootingAttack.WasPressedThisFrame() && canShoot)
        {
            playerAnims.Shoot();
            elapsedTime = 0;
            shotIntervalIndicator.size = 0;
            canShoot = false;   
            StartCoroutine(ShotInterval());
            GameObject shot = Instantiate(tankProjectilesManager.prefab, nozzle.transform.position, nozzle.rotation);
            Rigidbody shotrb = shot.GetComponent<Rigidbody>();
            shotrb.AddForce(nozzle.up * tankProjectilesManager.speed, ForceMode.Impulse);

            Destroy(shot, 10);
        }

        if (!canShoot)
        {
            elapsedTime += Time.deltaTime;
            shotIntervalIndicator.size = Mathf.Clamp01(elapsedTime / tankProjectilesManager.shotInterval);

        }
    }

    /*public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.action.WasPressedThisFrame() && canShoot)
        {
            canShoot = false;
            StartCoroutine(ShotInterval());
            GameObject shot = Instantiate(tankProjectilesManager.prefab, nozzle.transform.position, transform.rotation);
            Rigidbody shotrb = shot.GetComponent<Rigidbody>();
            shotrb.AddForce(shot.transform.up * tankProjectilesManager.speed, ForceMode.Impulse);

            Destroy(shot, 10);
        }
    }*/
    IEnumerator ShotInterval()
    {
        yield return new WaitForSeconds(tankProjectilesManager.shotInterval);
        canShoot = true;
    }
}