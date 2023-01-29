using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Zenject;

public class EnemyHealth : MonoBehaviour
{
    [Inject] private IGameStateService _gameStateService;
    [SerializeField] private Enemy _enemy;

    public event Action<float> OnHealthChanged;

    public float MaxHealth { get; private set; }

    public event Action OnEnemyKill;

    public float Health
    {
        get => _health;
        set
        {
            _health = Mathf.Clamp(value,0,MaxHealth);
            OnHealthChanged?.Invoke(_health);
            if (_health <= 0)
                OnEnemyKill?.Invoke();
        }
    }

    private float _health;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        MaxHealth = _enemy.Config.Health;
        Health = MaxHealth;

        OnEnemyKill += () => Destroy(gameObject);
        OnEnemyKill += () => _gameStateService.AddMoney(_enemy.Config.Price);
    }
}
