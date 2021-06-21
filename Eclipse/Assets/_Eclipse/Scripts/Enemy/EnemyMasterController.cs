using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMasterController : MonoBehaviour
{
    private EnemyStateMachine enemyStateMachine;
    public EnemyStateMachine EnemyStateMachine
    {
        get { return enemyStateMachine; }
    }

    private EnemyMovementController enemyMovementController;
    public EnemyMovementController EnemyMovementController
    {
        get { return enemyMovementController; }
    }

    private EnemyAttackController enemyAttackController;
    public EnemyAttackController EnemyAttackController
    {
        get { return enemyAttackController; }
    }

    private EnemyDamageController enemyDamageController;
    public EnemyDamageController EnemyDamageController
    {
        get { return enemyDamageController; }
    }

    private EnemyAnimationController enemyAnimationController;
    public EnemyAnimationController EnemyAnimationController
    {
        get { return enemyAnimationController; }
    }

    void Awake()
    {
        enemyStateMachine = GetComponent<EnemyStateMachine>();
        enemyMovementController = GetComponent<EnemyMovementController>();
        enemyAttackController = GetComponent<EnemyAttackController>();
        enemyDamageController = GetComponent<EnemyDamageController>();
        enemyAnimationController = GetComponent<EnemyAnimationController>();
    }
}
