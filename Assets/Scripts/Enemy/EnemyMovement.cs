using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class EnemyMovement : MonoBehaviour
{
    [Inject] private IGameStateService _gameStateService;
    [Inject] private ILinkService _linkService;

    [SerializeField] private Enemy _enemy;
    [SerializeField] private Vector3 _offset;

    private PathBlock _targetBlock;
    private Transform _target;

    public event Action OnEndMovement;

    private void Start()
    {
        transform.position = _linkService.StartBlock.transform.position;
        _targetBlock = _linkService.StartBlock;
        _target = _targetBlock.transform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position + _offset, _enemy.Config.Speed * Time.deltaTime);

        if (this.transform.position == _linkService.EndBlock.transform.position + _offset)
            OnEndMovement?.Invoke();

        if (this.transform.position == _targetBlock.transform.position + _offset && _targetBlock.Next == _linkService.EndBlock)
            _target = _linkService.EndBlock.transform;

        else if (this.transform.position == _targetBlock.transform.position + _offset)
        {
            _targetBlock = _targetBlock.Next as PathBlock;
            _target = _targetBlock.transform;
        }
    }

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        OnEndMovement += () => _gameStateService.RemoveBaseHealth(_enemy.Config.Damage);
        OnEndMovement += () => Destroy(this.gameObject);
    }

}
