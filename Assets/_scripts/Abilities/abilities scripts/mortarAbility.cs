using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class mortarAbility : MonoBehaviour
{
    public ParticleSystem initialSpark;
    public ParticleSystem Blast;

    public MeshRenderer meshRenderer;

    public AbilityStatsSO abilityStats;

    public LayerMask terrainLayer;

    public LayerMask enemyLayer;
    private bool contact;
    private bool hasExploded;


    // Update is called once per frame
    void Update()
    {
        contact = Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 0.5f, terrainLayer);
        //contact = Physics.BoxCast(transform.position, -Vector3.up, Vector3.down, transform.localRotation, 0.5f, terrainLayer);
        if (contact)
        {
            //hasExploded = true;
            initialSpark.Play();
            //TimeStopStrongEffect().Forget();
            StartCoroutine(TimeStop());
            Blast.Play();
            CameraShakeManager.instance.ZoomLerpIn(1);

            meshRenderer.enabled = false;

            Collider[] explosionArea = Physics.OverlapSphere(transform.position, 9, enemyLayer);
            foreach (var enemies in explosionArea)
            {
                enemies.TryGetComponent(out EnemyAttackBehaviour enemy);
                enemy.enemyHp -= abilityStats.abilityDamage;
            }
            Destroy(gameObject, 5);
        }
    }

    private CancellationTokenSource timeStopCts;

    async UniTask TimeStopStrongEffect()
    {
        /*timeStopCts?.Cancel();
        timeStopCts?.Dispose();
        timeStopCts = new CancellationTokenSource();*/

        Time.timeScale = 0f;
        await UniTask.Delay(TimeSpan.FromSeconds(0.3f), DelayType.Realtime /*,
            cancellationToken: timeStopCts.Token*/);
        CameraShakeManager.instance.CamShaker(6, 1);

        Time.timeScale = 1;

        await TimeStopStrongEffect();
    }

    IEnumerator TimeStop()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.3f);
        CameraShakeManager.instance.CamShaker(6, 1);

        Time.timeScale = 1;
    }


    public void Explode()
    {
    }
}