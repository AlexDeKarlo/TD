using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretsService : MonoBehaviour, ITurretsService
{
    [SerializeField] private List<Turret> _availableTurrets = new List<Turret>();
    public List<Turret> GetTurrets()
    {
        return _availableTurrets;
    }
}
