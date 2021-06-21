using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    public void TakeDamage(int damage, GlobalStateMachine.PhaseStates damageType)
    {
        // Matching damage type
        if (enemy.EnemyMasterController.EnemyStateMachine.CurrentPhaseState == damageType)
        {
            enemy.HitPoints = enemy.HitPoints - damage;
        }
        // Different damage type - does half damage
        else
        {
            enemy.HitPoints = enemy.HitPoints - (int)(damage * 0.5);
        }

        // Death
        if (enemy.HitPoints <= 0)
        {
            enemy.HitPoints = 0;
            // death delegate
        }
    }
}
