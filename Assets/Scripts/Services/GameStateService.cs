using System;
using UnityEngine;
using Zenject;

public class GameStateService : MonoBehaviour, IGameStateService
{
    [Inject] private IDataService _dataService;
    [Inject] private SceneUtility _sceneUtility;

    private int _money;
    private float _baseHealth;

    public event Action<int> OnAddMoney;
    public event Action<int> OnRemoveMoney;
    public event Action<float> OnAddBaseHealth;
    public event Action<float> OnRemoveBaseHealth;

    public int Money => _money;
    public float BaseHP => _baseHealth;

    private void Awake()
    {
        AddMoney(_dataService.GetData().StartMoney);
        AddBaseHealth(_dataService.GetData().StartBaseHP);
    }

    public void AddBaseHealth(float health)
    {
        if (health < 0) return;
        _baseHealth += health;
        OnAddBaseHealth?.Invoke(_baseHealth);
    }

    public void AddMoney(int money)
    {
        if (money < 0) return;
        _money += money;
        OnAddMoney?.Invoke(_money);
    }

    public void RemoveBaseHealth(float health)
    {
        if (health < 0) return; 
        _baseHealth -= health;
        OnRemoveBaseHealth?.Invoke(_baseHealth);
        if (_baseHealth <= 0) _sceneUtility.LoadScene(0);
    }

    public void RemoveMoney(int money)
    {
        if (money < 0) return;
        _money = _money -  money;
        OnRemoveMoney?.Invoke(_money);
    }
}
