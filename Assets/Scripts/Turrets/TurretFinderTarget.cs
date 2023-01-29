using System.Collections.Generic;
using UnityEngine;

public class TurretFinderTarget : MonoBehaviour
{
    [SerializeField] private Turret _turret;

    private EnemyDamageable _target;
    private List<EnemyDamageable> _targets = new List<EnemyDamageable>();

    public EnemyDamageable Target => _target;

    public event System.Action<EnemyDamageable> OnTargetChanged;

    private void AddTarget(EnemyDamageable enemyDamageable)
    {
        if (!_targets.Contains(enemyDamageable) && _target != enemyDamageable)
        {
            _targets.Add(enemyDamageable);
            enemyDamageable.OnDestroyEnemy += RemoveTarget;
            if(_target==null) UpdateTarget();
        }
    }
  
    private void RemoveTarget(EnemyDamageable enemyDamageable)
    {
        _targets.Remove(enemyDamageable);
        if (_target == enemyDamageable)
            UpdateTarget();
        
    }

    private void UpdateTarget()
    {
        if (_targets.Count == 0)
        {
            _target = null;
            OnTargetChanged?.Invoke(null);
        }
        else
        {
            _target = _targets[Random.Range(0, _targets.Count)];
            OnTargetChanged?.Invoke(_target);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyDamageable>())
            AddTarget(other.GetComponent<EnemyDamageable>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<EnemyDamageable>())
            RemoveTarget(other.GetComponent<EnemyDamageable>());
    }
}
