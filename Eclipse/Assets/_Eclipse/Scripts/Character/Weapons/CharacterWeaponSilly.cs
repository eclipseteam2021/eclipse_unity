using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterWeaponSilly : CharacterWeapon
{
    [SerializeField] private float primaryAttackDistance;
    [SerializeField] private float primaryAttackSlideTime;
    
    public override void StartPrimaryAttack(Vector3 clickPoint)
    {
        base.StartPrimaryAttack(clickPoint);
        
        characterMasterController.transform.LookAt(clickPoint);

        float slideDistance = Mathf.Min(Vector3.Distance(transform.position, clickPoint), primaryAttackDistance);
        
        characterMasterController.CharacterMovementController.LastDirection = characterMasterController.transform.rotation;

        Vector3 finalPos = transform.position + ((clickPoint - transform.position).normalized * slideDistance);
        
        characterMasterController.transform.DOMove(finalPos, primaryAttackSlideTime).OnComplete(AttackComplete);
    }

    public override void StartSecondaryAttack(Vector3 clickPoint)
    {
        base.StartSecondaryAttack(clickPoint);
        
        AttackComplete();
    }
}
