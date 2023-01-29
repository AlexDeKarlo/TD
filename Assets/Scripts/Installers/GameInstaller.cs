using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private DataService _dataService;
    [SerializeField] private GenerateService _generateService;
    [SerializeField] private LinkService _linkService;
    [SerializeField] private TurretsService _turretsService;
    [SerializeField] private EnemyService _enemyService;
    [SerializeField] private GameStateService _gameStateService;
    [SerializeField] private UIService _uiService;

    public override void InstallBindings()
    {
        Container.Bind<IDataService>().To<DataService>().FromInstance(_dataService).AsSingle().NonLazy();
        Container.Bind<IGenerateService>().To<GenerateService>().FromInstance(_generateService).AsSingle().NonLazy();
        Container.Bind<ILinkService>().To<LinkService>().FromInstance(_linkService).AsSingle().NonLazy();
        Container.Bind<ITurretsService>().To<TurretsService>().FromInstance(_turretsService).AsSingle().NonLazy();
        Container.Bind<IEnemyService>().To<EnemyService>().FromInstance(_enemyService).AsSingle().NonLazy();
        Container.Bind<IGameStateService>().To<GameStateService>().FromInstance(_gameStateService).AsSingle().NonLazy();
        Container.Bind<IShopUIService>().To<UIService>().FromInstance(_uiService).AsSingle().NonLazy();
    }
}