using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackController : CharacterSubController
{
    [SerializeField] 
    private GameObject startWeaponPrefab;
    
    private CharacterWeapon currentWeapon;

    protected override void Start()
    {
        base.Start();
        EquipWeapon(startWeaponPrefab);
    }

    void Update()
    {
        if (stateMachine.CurrentMovementState == CharacterStateMachine.MovementStates.Dashing)
            return;

        if (stateMachine.CurrentAttackState != CharacterStateMachine.AttackStates.NotAttacking)
        {
            //We're already attacking. Let the weapon do it's thing.
            return;
        }

        CheckMouseInput();
    }

    private void CheckMouseInput()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            RaycastHit hit; 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            
            if ( Physics.Raycast (ray,out hit,100.0f))
            {
                Vector3 hitPoint = new Vector3(hit.point.x, 0f, hit.point.z);
                
                if (Input.GetMouseButtonDown(0))
                {
                    currentWeapon.StartPrimaryAttack(hitPoint);
                    stateMachine.CurrentAttackState = CharacterStateMachine.AttackStates.PrimaryAttacking;
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    currentWeapon.StartSecondaryAttack(hitPoint);
                    stateMachine.CurrentAttackState = CharacterStateMachine.AttackStates.SecondaryAttacking;
                }
            }
        }
    }

    //Called by the weapon when it's finished doing it's thing.
    public void AttackComplete()
    {
        stateMachine.CurrentAttackState = CharacterStateMachine.AttackStates.NotAttacking;
    }
    
    public void EquipWeapon(GameObject weaponPrefab)
    {
        GameObject weaponGO = Instantiate(weaponPrefab, transform);
        currentWeapon = weaponGO.GetComponent<CharacterWeapon>();
        currentWeapon.EquipWeapon();
    }
}
