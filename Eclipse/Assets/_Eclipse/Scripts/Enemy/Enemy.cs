using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int hitpoints = 10;
    public int HitPoints { get { return hitpoints; } set { hitpoints = value; } }

    private EnemyMasterController enemyMasterController;
    public EnemyMasterController EnemyMasterController => enemyMasterController;

    private void Awake()
    {
        enemyMasterController = GetComponent<EnemyMasterController>();
    }
}
