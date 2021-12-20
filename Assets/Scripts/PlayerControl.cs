using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private IkArmControl ikArmControl;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        ikArmControl = GetComponent<IkArmControl>();
        InitializePlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        TransitionToWarState();
    }

    private void InitializePlayer()
    {
        playerMovement.enabled = true;
        ikArmControl.enabled = false;
    }

    private void TransitionToWarState()
    {
        playerMovement.enabled = false;
        ikArmControl.enabled = true;
    } 
}
