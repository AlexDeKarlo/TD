using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Configs/Enemy Config",fileName ="New Enemy Config")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField, Min(0)] private float _health;
    [SerializeField, Min(0)] private float _speed;
    [SerializeField, Min(0)] private float _damage;
    [SerializeField, Min(0)] private int _price;

    public float Health => _health;
    public float Speed => _speed;
    public int Price => _price;
    public float Damage => _damage;
}
