using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : MonoBehaviour
{
    [SerializeField]
    protected string primaryAnimTrigger;
    
    [SerializeField]
    protected string secondaryAnimTrigger;
    
    protected CharacterMasterController characterMasterController;
    protected CharacterStateMachine stateMachine;
    
    void Update()
    {
        if (stateMachine.CurrentAttackState == CharacterStateMachine.AttackStates.NotAttacking)
            return;
        else if (stateMachine.CurrentAttackState == CharacterStateMachine.AttackStates.PrimaryAttacking)
            RunPrimaryAttack();
        else if (stateMachine.CurrentAttackState == CharacterStateMachine.AttackStates.SecondaryAttacking)
            RunSecondaryAttack();
    }

    public virtual void EquipWeapon()
    {
        this.characterMasterController = CharacterMasterController.Instance;
        stateMachine = characterMasterController.CharacterStateMachine;
    }
    
    public virtual void StartPrimaryAttack(Vector3 hitPoint)
    {
        characterMasterController.CharacterAnimationController.Animator.SetTrigger(primaryAnimTrigger);
    }

    protected virtual void RunPrimaryAttack()
    {
        
    }
    
    public virtual void StartSecondaryAttack(Vector3 hitPoint)
    {
        characterMasterController.CharacterAnimationController.Animator.SetTrigger(secondaryAnimTrigger);
    }

    protected virtual void RunSecondaryAttack()
    {
        
    }

    protected void AttackComplete()
    {
        characterMasterController.CharacterAttackController.AttackComplete();
    }
}
