using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour, IPerson
{
    private ArmAnimIkEnemy armAnimIkEnemy;
    private float delayShoot = 3;
    private Transform playerPos;
    
    [SerializeField]
    private GameObject prefabBullet;
    [SerializeField]
    private Transform handPos;

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
        while (true)
        {
            GameObject bullet = Instantiate(prefabBullet, handPos.position 
                + transform.forward, Quaternion.identity);
            float randomLagTaget = Random.Range(-3, 3);
            Vector3 targetForBullet = playerPos.position + new Vector3(randomLagTaget, 0, 0);
            bullet.GetComponent<BulletControl>().
                SetTaret(transform.position, targetForBullet, 1, 1);

            yield return new WaitForSeconds(delayShoot);
        }
    }

}
