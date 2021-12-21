using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private IkArmControl ikArmControl;
    private ShootControl shootControl;

    [SerializeField]
    private PersonAttributes attributes;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        ikArmControl = GetComponent<IkArmControl>();
        shootControl = GetComponent<ShootControl>();
        Initialize();
    }

    public void Initialize()
    {
        playerMovement.enabled = true;
        ikArmControl.enabled = false;
        shootControl.enabled = false;

        playerMovement.SetSpeed(attributes.SpeedMoving);
        shootControl.SetSpeedShooting(attributes.SpeedShooting);
    }

    private void OnTriggerEnter(Collider other)
    {
        TransitionToWarState();
    }

    private void TransitionToWarState()
    {
        shootControl.enabled = true;
        playerMovement.enabled = false;
        ikArmControl.enabled = true;
        EventsBroker.PlayerStartedFight();
    }

    
}
