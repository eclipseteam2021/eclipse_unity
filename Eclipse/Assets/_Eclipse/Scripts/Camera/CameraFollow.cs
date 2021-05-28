using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform followTarget;
    
    [SerializeField]
    private Vector3 followOffset;

    void FixedUpdate()
    {
        transform.position = followTarget.position + followOffset;
    }
}
