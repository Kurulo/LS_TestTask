using UnityEngine;
using Zenject;

public class UniversalFabricInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<UniversalFactory>().ToSelf().AsSingle();
    }
}