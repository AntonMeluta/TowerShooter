using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    private Rigidbody body;
    private Vector3 direction;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    public void SetTaret(Vector3 target)
    {
        direction = target - transform.position;
    }

    private void FixedUpdate()
    {
        body.velocity = direction;
    }
}
