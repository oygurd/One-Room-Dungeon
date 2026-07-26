using System;
using UnityEngine;

public class StasPowerManager : MonoBehaviour
{
    public PowerUpStatsScriptableObject StatsSO;
    private MeshRenderer skin;
    
    [SerializeField] private TankProjectilesManager PlayerDamage;
    [SerializeField] private BasicPlayerStats  playerSpeed;
    [SerializeField] private ParticleSystem powerUpSprite;


    private void Start()
    {
        skin = GetComponent<MeshRenderer>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerDamage.damage += StatsSO.damage;
            playerSpeed.speed += StatsSO.speed;
            
            skin.enabled = false;
            
            powerUpSprite.Play();
            Destroy(gameObject,2.5f);
        }
    }
}
