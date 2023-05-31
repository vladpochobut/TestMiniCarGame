using System.Collections;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{ 
    public abstract void RiseSpeed(float speedUpValue);
    public abstract float GetSpeed();
    public abstract void SpeedDeceleration(float slowdownValue);
}
