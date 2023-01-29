using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StatsVisual : MonoBehaviour
{
    [Inject] private IGameStateService gameStateService;

    [SerializeField] private Slider _slider;
    [SerializeField] private TMPro.TMP_Text _healthText;
    [SerializeField] private TMPro.TMP_Text _moneyText;

    private void Start()
    {
        _slider.maxValue = gameStateService.BaseHP;
        _slider.value = gameStateService.BaseHP;
        _healthText.text = $"HP: {gameStateService.BaseHP}";
        _moneyText.text = $"Money: {gameStateService.Money}";

        gameStateService.OnAddBaseHealth += (e) => UpdateHealth(e);
        gameStateService.OnRemoveBaseHealth += (e) => UpdateHealth(e);
        gameStateService.OnAddMoney += (e) => UpdateMoney(e);
        gameStateService.OnRemoveMoney += (e) => UpdateMoney(e);
    }

    
    private void UpdateHealth(float health)
    {
        _slider.value = health;
        _healthText.text = $"HP: {health}";
    }
    private void UpdateMoney(int money)
    {
        _moneyText.text = $"Money: {money}";
    }
}
