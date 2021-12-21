using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent meshAgent;
    private Animator animator;

    private void Awake()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        EventsBroker.OnTap += GoTargetMoving;
    }

    private void OnDisable()
    {
        EventsBroker.OnTap -= GoTargetMoving;
        animator.SetFloat("speedMove", 0);
    }

    private void Update()
    {
        animator.SetFloat("speedMove", meshAgent.velocity.magnitude);
    }

    public void SetSpeed(float speed)
    {
        meshAgent.speed = speed;
    }

    private void GoTargetMoving(Vector3 destination)
    {
        meshAgent.destination = destination;
    }
    
}
