using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private PlayerController _playeController;

    public override void InstallBindings() {
        PlayerController player = Container.
            InstantiatePrefabForComponent<PlayerController>(
            _playeController, 
            _spawnPosition.position, 
            Quaternion.identity, 
            null);

        Container.Bind<PlayerController>().FromInstance(player).AsSingle();
    }
}