using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationShooter : TurretShooter
{
    private Animator _animator;

    protected sealed override void ChangeTarget(EnemyDamageable target)
    {
        if (target != null) 
            _animator.Play("Shoot");
        else
            _animator.Play("IDLE");
    }

    protected override void Initialize()
    {
        base.Initialize();
        _animator = GetComponent<Animator>();
        _animator.speed = 1 / _turret.Config.Cooldown;
    }
}
