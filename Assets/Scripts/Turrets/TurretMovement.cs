using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    [SerializeField] private TurretFinderTarget _turretFinderTarget;


    private void Update()
    {
        if(_turretFinderTarget.Target!=null)
        transform.LookAt(new Vector3(_turretFinderTarget.Target.transform.position.x,transform.position.y, _turretFinderTarget.Target.transform.position.z));
    }
}
