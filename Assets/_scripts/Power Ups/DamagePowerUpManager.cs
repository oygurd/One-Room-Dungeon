using UnityEngine;

public class DamagePowerUpManager : MonoBehaviour
{
    [SerializeField] private TankProjectilesManager PlayerDamage;
    [SerializeField] private ParticleSystem powerUpSprite;
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerDamage.damage += 1;
            powerUpSprite.transform.parent = null;
            powerUpSprite.Play();
            Destroy(gameObject);
        }
    }
}
