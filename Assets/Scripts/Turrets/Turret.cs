using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Turret : MonoBehaviour
{
    [SerializeField] private TurretConfig _turretConfig;
    public TurretConfig Config => _turretConfig;
}
