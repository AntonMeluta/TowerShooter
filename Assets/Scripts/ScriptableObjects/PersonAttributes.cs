using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Person Attributes", menuName = "Person/New Attributes", order = 51)]
public class PersonAttributes : ScriptableObject
{
    [SerializeField]
    private BulletProperties bulletProperties;
    [SerializeField]
    private float speedMoving = 3.5f;
    [Range(0.3f, 0.7f)]
    [SerializeField]
    private float speedShooting = 3.5f;

    public BulletProperties BulletProperties => bulletProperties;
    public float SpeedMoving => speedMoving;
    public float SpeedShooting => speedShooting;

}
