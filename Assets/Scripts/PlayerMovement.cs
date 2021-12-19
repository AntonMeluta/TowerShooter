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

    public void GoTargetMoving(Vector3 destination)
    {
        //meshAgent.destination = destination;
    }

    private void Update()
    {

        animator.SetFloat("speedMove", meshAgent.velocity.magnitude);
        if (Input.GetKeyDown(KeyCode.E))
            animator.SetBool("isWalk", true);
        if (Input.GetKeyUp(KeyCode.E))
            animator.SetBool("isWalk", false);
    }
}
