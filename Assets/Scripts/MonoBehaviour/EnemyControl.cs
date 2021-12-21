using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour, IPerson
{
    private ArmAnimIkEnemy armAnimIkEnemy;
    private float delayShoot = 3;
    private Transform playerPos;
    private PoolObject poolBullets;

    [SerializeField]
    private GameObject prefabBullet;
    [SerializeField]
    private Transform handPos;

    private void Awake()
    {
        poolBullets = GameObject.Find("BulletPool").GetComponent<PoolObject>();
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
        StartCoroutine(ShootToPlayer());
    }

    private IEnumerator ShootToPlayer()
    {
        yield return new WaitForSeconds(Random.Range(0.2f, 1.5f));
        while (true)
        {
            GameObject bullet = poolBullets.GetPooledObject();
            bullet.transform.position = handPos.position + transform.forward;
            float randomLagTaget = Random.Range(-3, 3);
            Vector3 targetForBullet = playerPos.position + new Vector3(randomLagTaget, 1.3f, 0);
            bullet.GetComponent<BulletControl>().
                SetTaret(transform.position, targetForBullet, 1, 1);
            bullet.SetActive(true);

            yield return new WaitForSeconds(delayShoot);
        }
    }

}
