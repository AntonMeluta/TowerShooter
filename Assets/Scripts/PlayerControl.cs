using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private IkArmControl ikArmControl;
    private ShootControl shootControl;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        ikArmControl = GetComponent<IkArmControl>();
        shootControl = GetComponent<ShootControl>();
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
        shootControl.enabled = false;
    }

    private void TransitionToWarState()
    {
        shootControl.enabled = true;
        playerMovement.enabled = false;
        ikArmControl.enabled = true;
        
    } 
}
