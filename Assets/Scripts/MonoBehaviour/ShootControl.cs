using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour
{
    private float delayBetweenShoots;
    private float delta = 0;
    private bool isPermission = true;

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
        EventsBroker.OnTap += ShootingProcess;
        StartCoroutine(ShootingSpeedController());
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
            GameObject bullet = Instantiate(prefabBullet, handPos.position
            + transform.forward / 3, Quaternion.identity);
            bullet.GetComponent<BulletControl>().SetTaret(transform.position, vectorMove,
                attributes.BulletProperties.ForceShoot, attributes.BulletProperties.LiftShoot);
            isPermission = false;
            StartCoroutine(ShootingSpeedController());
        }        
    }

    private IEnumerator ShootingSpeedController()
    {
        float delta = 1 - speedShooting;
        while (delta > 0)
        {
            delta -= Time.deltaTime;
            yield return null;
        }
        isPermission = true;
    }
}
