using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterStateMachine : GlobalStateMachine
{
    public enum MovementStates { Idle, Moving, Dashing }
    private MovementStates currentMovementState = MovementStates.Idle;
    public delegate void MovementStateChangedDelegate(MovementStates newMovementState);
    public MovementStateChangedDelegate movementStateChangedDelegate;
    
    public enum AttackStates { NotAttacking, PrimaryAttacking, SecondaryAttacking }
    private AttackStates currentAttackState = AttackStates.NotAttacking;
    public delegate void AttackStateChangedDelegate(AttackStates newAttackState);
    public AttackStateChangedDelegate attackStateChangedDelegate;
    
    public MovementStates CurrentMovementState
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
}
