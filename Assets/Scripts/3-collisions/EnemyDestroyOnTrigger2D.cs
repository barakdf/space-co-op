using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyOnTrigger2D : DestroyOnTrigger2D
{
    [SerializeField] int enemyScore;
    
    public int GetEnemyScore() {
        return this.enemyScore;
    }
}
