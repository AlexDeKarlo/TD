using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShooter : TurretShooter
{
    protected sealed override void ChangeTarget(EnemyDamageable target)
    {
        StopAllCoroutines();
        if (target != null)
            StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(_turret.Config.Cooldown);
            Shoot();
        }
    }

}
