using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkArmControl : MonoBehaviour
{
    private Animator animator;

    private bool ikActive = false;
    [SerializeField]
    private Transform rightHandObj = null;

    private void OnEnable()
    {
        EventsBroker.OnTap += ArmIkAnimControl;
        EventsBroker.OnTapUpdateState += UpdateTapState;
    }

    private void OnDisable()
    {
        EventsBroker.OnTap -= ArmIkAnimControl;
        EventsBroker.OnTapUpdateState -= UpdateTapState;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void UpdateTapState(bool isTap)
    {
        ikActive = isTap;
    }

    private void ArmIkAnimControl(Vector3 newPosCube)
    {
        rightHandObj.transform.rotation = Quaternion.Euler(-90, -90, 0);
        rightHandObj.transform.position = newPosCube;
    }

    //a callback for calculating IK
    private void OnAnimatorIK()
    {
        if (ikActive)
        {
            if (rightHandObj != null)
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
            }
        }
        else
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            animator.SetLookAtWeight(0);
        }
    }
}
