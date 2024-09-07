using UnityEngine;
using Zenject;

public class GameControllerInstaller : MonoInstaller
{
    [Header("Game Controller Reference")]
    [SerializeField] private GameController _controller;

    public override void InstallBindings() {
        GameController controller = Container.InstantiatePrefabForComponent<GameController>(_controller);

        Container.Bind<GameController>().FromInstance(controller).AsSingle();
    }
}