using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : MonoBehaviour, IEnemyService
{
    [SerializeField] private List<Enemy> _enemyList = new List<Enemy>();
    public List<Enemy> GetEnemies()
    {
        return _enemyList;
    }
}
