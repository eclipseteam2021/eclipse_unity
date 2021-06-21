using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : GlobalStateMachine
{
    public enum EnemyStates { Idle, Searching, Chasing, Attacking }
    protected EnemyStates currentEnemyState = EnemyStates.Idle;
    public delegate void EnemyStateChangedDelegate(EnemyStates newEnemyState);
    public EnemyStateChangedDelegate enemyStateChangedDelegate;

    public enum MovementStates { Idle, Moving, Attacking }
    protected MovementStates currentMovementState = MovementStates.Idle;
    public delegate void MovementStateChangedDelegate(MovementStates newMovementState);
    public MovementStateChangedDelegate movementStateChangedDelegate;

    public enum AttackStates { NotAttacking, Attacking }
    protected AttackStates currentAttackState = AttackStates.NotAttacking;
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
