using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterWeaponSilly : CharacterWeapon
{
    [SerializeField] private float primaryAttackDistance;
    
    public override void StartPrimaryAttack(Vector3 clickPoint)
    {
        base.StartPrimaryAttack(clickPoint);
        
        characterMasterController.transform.LookAt(clickPoint);
        characterMasterController.CharacterMovementController.LastDirection = characterMasterController.transform.rotation;
        
        characterMasterController.transform.DOJump(clickPoint, 4f, 1, 0.6f).OnComplete(AttackComplete);
    }

    public override void StartSecondaryAttack(Vector3 hitPoint)
    {
        base.StartSecondaryAttack(hitPoint);
        
        AttackComplete();
    }
}
