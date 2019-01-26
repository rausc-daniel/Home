using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform Target;
    [Range (-5, 5)] public float offsetX;
    public float offsetY;
    [Range (-10, 0)] public float offsetZ;
    [Range (0, 1)] public float TimeToReach;

    private Vector3 offset;
    private Vector3 curVel;

    public void UpdateTarget(Transform target)
    {
        Target = target;
    }

    void LateUpdate()
    {
        offset = new Vector3(offsetX, offsetY, offsetZ);
        transform.position = Vector3.SmoothDamp(transform.position, Target.position + offset, ref curVel, TimeToReach);
    }
}
