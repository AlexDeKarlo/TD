using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Configs/Turret Config", fileName = "New Turret Config")]
public class TurretConfig : ScriptableObject
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private string _name;
    [SerializeField] private int _bulletspeed;
    [SerializeField] private int _price;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _range;
    [SerializeField] private float _damage;


    public Bullet Bullet => _bulletPrefab;
    public string Name => _name;
    public int BulletSpeed => _bulletspeed;
    public int Price => _price;
    public float Cooldown => _cooldown;
    public float Range => _range;
    public float Damage => _damage;
}
