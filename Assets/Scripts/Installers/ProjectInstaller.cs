using System.ComponentModel;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private SceneUtility _sceneUtility;

    public override void InstallBindings()
    {
        Container.Bind<SceneUtility>().FromInstance(_sceneUtility).AsSingle().NonLazy();
    }
}