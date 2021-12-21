using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    private Rigidbody body;
    private Vector3 direction;
    private float force;
    private float lift;
    private Vector3 shooterPos;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    public void SetTaret(Vector3 shooter, Vector3 target, float getForce, float getLift)
    {
        shooterPos = shooter;
        direction = target - transform.position;
        force = getForce;
        lift = getLift;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent(typeof(IDestructible)))
            collision.gameObject.GetComponent<IDestructible>().
                OnDestruction(shooterPos, force, lift);
    }

    private void FixedUpdate()
    {
        body.velocity = direction;
        transform.LookAt(direction);
    }
}
