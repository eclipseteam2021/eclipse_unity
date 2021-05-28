using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class CharacterMovementController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    
    [SerializeField]
    private float movementSpeed;
    
    [SerializeField]
    private float dashSpeed;
    
    [SerializeField]
    private float dashDistance;
    
    [SerializeField]
    private float rotationSpeed;

    private CharacterStateMachine stateMachine;

    private Quaternion lastDirection = Quaternion.identity;
    
    private Vector3 dashTargetLocation;

    void Start()
    {
        stateMachine = CharacterMasterController.Instance.CharacterStateMachine;
    }
    
    private void Update()
    {
        //Don't move during attack anims
        if (stateMachine.currentAttackState != CharacterStateMachine.AttackStates.NotAttacking)
            return;
        
        //Already dashing
        if (stateMachine.currentMovementState == CharacterStateMachine.MovementStates.Dashing)
        {
            RunDash();
        }
        else
        {
            Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            
            if (Input.GetButtonDown("Dash"))
            {
                StartDash(movementVector);
            }
            else
            {
                RunMove(movementVector);
            } 
        }
    }

    private void RunMove(Vector3 movementVector)
    {
        bool moving = movementVector != Vector3.zero;
        
        animator.SetBool("Moving", moving);
        
        if (moving)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + movementVector.normalized, movementSpeed * Time.deltaTime);
            
            stateMachine.currentMovementState = CharacterStateMachine.MovementStates.Moving;
            lastDirection = Quaternion.LookRotation(movementVector);
        }
        else
        {
            stateMachine.currentMovementState = CharacterStateMachine.MovementStates.Idle;
        }

        transform.rotation = Quaternion.Lerp( transform.rotation, lastDirection, rotationSpeed * Time.deltaTime );
    }
    
    private void RunDash()
    {
        transform.position = Vector3.Lerp(transform.position, dashTargetLocation, dashSpeed * Time.deltaTime);

        //Dash Complete Check
        if (Vector3.Distance(transform.position, dashTargetLocation) < 0.1f)
        {
            stateMachine.currentMovementState = CharacterStateMachine.MovementStates.Idle;
        }
    }

    public void StartDash(Vector3 movementDirection)
    {
        if (movementDirection == Vector3.zero)
            movementDirection = transform.forward;
        
        dashTargetLocation = transform.position + (movementDirection.normalized * dashDistance);
        
        stateMachine.currentMovementState = CharacterStateMachine.MovementStates.Dashing;
    }
}
