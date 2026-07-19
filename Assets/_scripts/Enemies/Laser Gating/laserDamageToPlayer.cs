using UnityEngine;

public class laserDamageToPlayer : MonoBehaviour
{
   public LaserGatingScannerBehaviour laserGatingScannerBehaviour;

   public bool hasHitPlayer;
   public bool attackLaserActive;
   RaycastHit laserHitPlayer;
   public LayerMask playerMask;

   GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CastLaserDamage();
        
    }
    private void CastLaserDamage()
    {
        
        attackLaserActive = Physics.Raycast(transform.position,- transform.right, out laserHitPlayer, laserGatingScannerBehaviour.distanceFromAlly, 
            playerMask);

        if (attackLaserActive && !hasHitPlayer)
        {
            hasHitPlayer = true;
            player = laserHitPlayer.transform.gameObject;
            if (player.TryGetComponent(out PlayerHealth playergo))
            {
                playergo.LowerHp(1);
            }
        }

        if (!attackLaserActive)
        {
           hasHitPlayer = false;
        }
    }
}
