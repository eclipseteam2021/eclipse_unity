using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    
    [SerializeField]
    private float movementSpeed;
    
    [SerializeField]
    private float rotationSpeed;

    private Quaternion lastDirection = Quaternion.identity;

    void Start()
    {

    }
    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        
        transform.position = Vector3.Lerp(transform.position, transform.position + movementVector.normalized, movementSpeed * Time.fixedDeltaTime);

        if (movementVector != Vector3.zero)
        {
            lastDirection = Quaternion.LookRotation(movementVector);
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        transform.rotation = Quaternion.Lerp( transform.rotation, lastDirection, rotationSpeed * Time.fixedDeltaTime );
    }
}
