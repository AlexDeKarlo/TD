using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public interface IGameStateService
{
    public int Money { get; }
    public float BaseHP { get; }

    public event Action<int> OnAddMoney;
    public event Action<int> OnRemoveMoney;
    public event Action<float> OnAddBaseHealth;
    public event Action<float> OnRemoveBaseHealth;



    public void AddMoney(int Money);
    public void RemoveMoney(int Money);

    public void AddBaseHealth(float health);
    public void RemoveBaseHealth(float health);
}
