using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructedRagdoll : MonoBehaviour
{
    [SerializeField]
    private RagdollBody RagdollObject;
    [SerializeField]
    private float Force;
    [SerializeField]
    public float Lift;

    public void OnDestruction(Transform destroyer)
    {
        RagdollBody ragdoll = Instantiate(RagdollObject, transform.position, transform.rotation);

        Vector3 vectorFromDestroyer = transform.position - destroyer.position;
        vectorFromDestroyer.Normalize();
        vectorFromDestroyer.y += Lift;

        ragdoll.ApplyForce(vectorFromDestroyer * Force);
    }
}
