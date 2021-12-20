using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollBody : MonoBehaviour
{
    [SerializeField]
    private Rigidbody ragdollSpine;
    [SerializeField]
    private float timeToLive;

    private void OnEnable()
    {
        Destroy(gameObject, timeToLive);
    }

    public void ApplyForce(Vector3 force)
    {
        ragdollSpine.AddForce(force);
    }
}
