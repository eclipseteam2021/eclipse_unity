using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMasterController : Singleton<CharacterMasterController>
{
    private CharacterStateMachine characterStateMachine;
    public CharacterStateMachine CharacterStateMachine
    {
        get { return characterStateMachine; }
    }
    
    private CharacterMovementController characterMovementController;
    public CharacterMovementController CharacterMovementController
    {
        get { return characterMovementController; }
    }
    
    private CharacterAttackController characterAttackController;
    public CharacterAttackController CharacterAttackController
    {
        get { return characterAttackController; }
    }
    
    private CharacterDamageController characterDamageController;
    public CharacterDamageController CharacterDamageController
    {
        get { return characterDamageController; }
    }
    
    private CharacterAnimationController characterAnimationController;
    public CharacterAnimationController CharacterAnimationController
    {
        get { return characterAnimationController; }
    }

    void Awake()
    {
        characterStateMachine = GetComponent<CharacterStateMachine>();
        characterMovementController = GetComponent<CharacterMovementController>();
        characterAttackController = GetComponent<CharacterAttackController>();
        characterDamageController = GetComponent<CharacterDamageController>();
        characterAnimationController = GetComponent<CharacterAnimationController>();
    }
}