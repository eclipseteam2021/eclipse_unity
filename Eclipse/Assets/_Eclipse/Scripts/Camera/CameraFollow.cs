using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform followTarget;
    
    [SerializeField]
    private Vector3 followOffset;

    void Update()
    {
        transform.position = followTarget.position + followOffset;
    }
}
