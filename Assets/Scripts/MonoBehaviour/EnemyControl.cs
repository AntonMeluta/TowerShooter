using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private ArmAnimIkEnemy armAnimIkEnemy;
    
    private Transform playerPos;
    private PoolObject poolBullets;
    private float delay;
    private float accuracy;

    [SerializeField]
    private float delayBetweenShootAverage = 3;
    [SerializeField]
    private float shotAccuracyAverage = 3;
    [SerializeField]
    private GameSettings gameSettings;
    [SerializeField]
    private Transform handPos;

    private void Awake()
    {
        poolBullets = GameObject.Find("BulletPoolEnemy").GetComponent<PoolObject>();
    }

    private void OnEnable()
    {
        armAnimIkEnemy = GetComponent<ArmAnimIkEnemy>();
        playerPos = FindObjectOfType<PlayerControl>().transform;
        Initialize();        
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void Initialize()
    {
        switch (gameSettings.DifficultyGame)
        {
            case DifficultyGame.easy:
                delay = delayBetweenShootAverage + 1;
                accuracy = shotAccuracyAverage + 1;
                break;
            case DifficultyGame.middle:
                delay = delayBetweenShootAverage;
                accuracy = shotAccuracyAverage;
                break;
            case DifficultyGame.hard:
                delay = delayBetweenShootAverage - 1;
                accuracy = shotAccuracyAverage - 1;
                break;
            default:
                break;
        }

        StartCoroutine(ShootToPlayer());
    }

    private IEnumerator ShootToPlayer()
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 4f));
        while (true)
        {
            GameObject bullet = poolBullets.GetPooledObject();
            bullet.transform.position = handPos.position + transform.forward;
            float randomLagTaget = Random.Range(-accuracy, accuracy);
            Vector3 targetForBullet = playerPos.position + new Vector3(randomLagTaget, 1.3f, 0);
            bullet.GetComponent<BulletControl>().
                SetTaret(transform.position, targetForBullet, 1, 1);
            bullet.SetActive(true);

            yield return new WaitForSeconds(delay);
        }
    }

}
