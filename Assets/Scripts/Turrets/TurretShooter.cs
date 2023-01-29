using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(SphereCollider))]
public abstract class TurretShooter : MonoBehaviour 
{
    [SerializeField] protected Turret _turret;
    [SerializeField] protected TurretFinderTarget _turretFinderTarget;

    [SerializeField] protected Transform _spawnPoint;

    private SphereCollider _sphereCollider;

    protected abstract void ChangeTarget(EnemyDamageable target);

    protected virtual void Shoot()
    {
        Instantiate(_turret.Config.Bullet, _spawnPoint.position, Quaternion.identity).SetTarget(_turret.Config.BulletSpeed, _turret.Config.Damage, _turretFinderTarget.Target.transform);
    }

    private void Awake()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _sphereCollider.radius = _turret.Config.Range;
        _turretFinderTarget.OnTargetChanged += ChangeTarget;
    }
}
