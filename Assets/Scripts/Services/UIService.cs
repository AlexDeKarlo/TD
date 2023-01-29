using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIService : MonoBehaviour, IShopUIService
{
    [SerializeField] ShopVisual _shopVisual;
    public ShopVisual ShopVisual => _shopVisual;


}
