using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAnimIkEnemy : MonoBehaviour
{
    private Transform playerPos;
    private Animator animator;

    private void Start()
    {
        playerPos = FindObjectOfType<PlayerControl>().transform;
        animator = GetComponent<Animator>();
    }
    
    //a callback for calculating IK
    private void OnAnimatorIK()
    {
        if (playerPos != null)
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            animator.SetIKPosition(AvatarIKGoal.RightHand, playerPos.position);
            animator.SetIKRotation(AvatarIKGoal.RightHand, playerPos.rotation);
        }
    }
}
