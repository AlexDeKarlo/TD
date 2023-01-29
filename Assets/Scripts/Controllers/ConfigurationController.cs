using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ConfigurationController : MonoBehaviour
{
    [Inject] private IDataService _dataService;
    [Inject] private IGenerateService _generateService;
    [Inject] private ILinkService _linkService;

    private GenerationData _data;

    private void Awake()
    {
        _data = _dataService.GetData();
        _linkService.Link(_generateService.Generate(_data));
    }
}

