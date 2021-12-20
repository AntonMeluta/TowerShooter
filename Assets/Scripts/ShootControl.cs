using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabBullet;

    private void OnEnable()
    {
        EventsBroker.OnTap += ShootingProcess;
    }

    private void OnDisable()
    {
        EventsBroker.OnTap -= ShootingProcess;
    }

    private void ShootingProcess(Vector3 vectorMove)
    {
        GameObject bullet = Instantiate(prefabBullet, transform.position + Vector3.forward, 
            Quaternion.Euler(90, 0, 0));
        bullet.GetComponent<BulletControl>().SetTaret(vectorMove);

    }
}
