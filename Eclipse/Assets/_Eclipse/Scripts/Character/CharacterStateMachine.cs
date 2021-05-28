using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterStateMachine : MonoBehaviour
{
    public enum MovementStates { Idle, Moving, Dashing }
    public MovementStates currentMovementState = MovementStates.Idle;
    public delegate void MovementStateChangedDelegate(MovementStates newMovementState);
    public MovementStateChangedDelegate movementStateChangedDelegate;
    
    public enum AttackStates { NotAttacking, PrimaryAttacking, SecondaryAttacking }
    public AttackStates currentAttackState = AttackStates.NotAttacking;
    public delegate void AttackStateChangedDelegate(AttackStates newAttackState);
    public AttackStateChangedDelegate attackStateChangedDelegate;
    
    public enum VulnerabilityStates { Normal, Damaged, Invulnerable }
    public VulnerabilityStates currentVulnerabilityState = VulnerabilityStates.Normal;
    public delegate void VulnerabilityStateChangedDelegate(VulnerabilityStates newSubState);
    public VulnerabilityStateChangedDelegate vulnerabilityStateChangedDelegate;
    
    public MovementStates CurrentMovementStates
    {
        get
        {
            return currentMovementState;
        }
        set
        { 
            currentMovementState = value;
            movementStateChangedDelegate?.Invoke(currentMovementState);
        } 
    }
    
    public AttackStates CurrentAttackState
    {
        get
        {
            return currentAttackState;
        }
        set
        { 
            currentAttackState = value;
            attackStateChangedDelegate?.Invoke(currentAttackState);
        } 
    }
    
    public VulnerabilityStates CurrentVulnerabilityState
    {
        get
        {
            return currentVulnerabilityState;
        }
        set
        { 
            currentVulnerabilityState = value;
            vulnerabilityStateChangedDelegate?.Invoke(currentVulnerabilityState);
        } 
    }
}
