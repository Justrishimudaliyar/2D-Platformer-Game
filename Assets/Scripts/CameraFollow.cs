using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1,10)]
    public float smoothFactor;

    void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPostion = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPostion, smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothedPosition;
    }
}
