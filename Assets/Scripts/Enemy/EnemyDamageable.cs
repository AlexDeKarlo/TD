using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageable : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    public event Action<EnemyDamageable> OnDestroyEnemy;
    public void ApplyDamage(float damage)
    {
        if(damage<0)
            throw new System.ArgumentOutOfRangeException(nameof(damage));

        _enemyHealth.Health -= damage;
    }
    private void OnDestroy() => OnDestroyEnemy?.Invoke(this);
}
