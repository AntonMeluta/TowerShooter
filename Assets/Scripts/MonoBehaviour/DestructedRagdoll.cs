using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructedRagdoll : MonoBehaviour, IDestructible
{
    [SerializeField]
    private RagdollBody ragdollObject;

    public void OnDestruction(Vector3 destroyer, float getForce, float getLift)
    {
        RagdollBody ragdoll = Instantiate(ragdollObject, transform.position, transform.rotation);

        Vector3 vectorFromDestroyer = transform.position - destroyer;
        vectorFromDestroyer.Normalize();
        vectorFromDestroyer.y += getLift;

        ragdoll.ApplyForce(vectorFromDestroyer * getForce);

        gameObject.SetActive(false);  
    }
}
