
using UnityEngine;

public interface IDestructible
{
    void OnDestruction(Vector3 destroyer, float getForce, float getLift);
}
