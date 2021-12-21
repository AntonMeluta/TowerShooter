using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour
{
    private float delayBetweenShoots;
    private float delta = 0;
    private bool isPermission;

    [SerializeField]
    private PoolObject poolBullets;
    [SerializeField]
    private GameObject prefabBullet;
    [SerializeField]
    private float speedShooting;
    [SerializeField]
    private Transform handPos;
    [SerializeField]
    private PersonAttributes attributes;

    private void OnEnable()
    {
        isPermission = true;
        EventsBroker.OnTap += ShootingProcess;
    }

    private void OnDisable()
    {
        EventsBroker.OnTap -= ShootingProcess;
    }

    public void SetSpeedShooting(float speed)
    {
        speedShooting = speed;
    }

    private void ShootingProcess(Vector3 vectorMove)
    {
        if (isPermission)
        {
            print("ShootingProcess(Vector3 vectorMove)");
            GameObject bullet = poolBullets.GetPooledObject();
            bullet.transform.position = handPos.position + transform.forward / 3;
            bullet.GetComponent<BulletControl>().SetTaret(transform.position, vectorMove,
                attributes.BulletProperties.ForceShoot, attributes.BulletProperties.LiftShoot);
            bullet.SetActive(true);            
            StartCoroutine(ShootingSpeedController());
        }        
    }

    private IEnumerator ShootingSpeedController()
    {
        float delta = 1 - speedShooting;
        isPermission = false;
        print("ShootingProcess(Vector3 vectorMove) 2");

        while (delta > 0)
        {
            delta -= Time.deltaTime;
            yield return null;
        }

        isPermission = true;
    }
}
