using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShopVisual : MonoBehaviour
{
    [SerializeField] private GameObject _buyTurretCanvas;

    [SerializeField] private Transform _content;
    [SerializeField] private TurretUIContent _turretUIPrefab;

    [Inject] private ITurretsService _turretsService;
    [Inject] private IGameStateService _gameStateService;

    private List<TurretUIContent> _tempContent = new List<TurretUIContent>();
    public void Show(TurretBaseBlock currentBaseBlock)
    {
        Disable();
        List<Turret> turrets = new List<Turret>();
        turrets = _turretsService.GetTurrets();

        _buyTurretCanvas.SetActive(true);

        for (int i = 0; i < turrets.Count; i++)
        {
            TurretUIContent content = Instantiate(_turretUIPrefab, _content);
            GameObject turret = turrets[i].gameObject;
            content.Name.text = turrets[i].Config.Name;
            content.Description.text = $"Price: {turrets[i].Config.Price}\r\nDamage: {turrets[i].Config.Damage}\r\nRange: {turrets[i].Config.Range}\r\nCooldown: {turrets[i].Config.Cooldown}";
            int Price = turrets[i].Config.Price;
            content.Buy.onClick.AddListener(() =>
            {
                _buyTurretCanvas.SetActive(false);
                if (_gameStateService.Money < Price) return;
                _gameStateService.RemoveMoney(Price);
                Instantiate(turret, currentBaseBlock.transform.position + Vector3.up / 2, Quaternion.identity, currentBaseBlock.transform);
                currentBaseBlock.GetComponent<Collider>().enabled = false;
            });
            _tempContent.Add(content);
        }
    }
    private void Disable()
    {
        for (int i = 0; i < _tempContent.Count; i++)
        {
            Destroy(_tempContent[i].gameObject);
        }
        _tempContent.Clear();
    }
}
