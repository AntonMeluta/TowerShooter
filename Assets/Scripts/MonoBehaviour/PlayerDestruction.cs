using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestruction : MonoBehaviour, IDestructible
{
    
    public void OnDestruction(Vector3 destroyer, float getForce, float getLift)
    {
        print("Игрок получил луз"); //Событие поражения!!!
    }
}
