using System;
using UnityEngine;

[Serializable]
public struct BulletProperties
{
    [SerializeField]
    private float forceShoot;
    [SerializeField]
    private float liftShoot;

    public float ForceShoot => forceShoot;
    public float LiftShoot => liftShoot;
}
