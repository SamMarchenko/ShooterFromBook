using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public Transform PlayerSpawnPoint;
    public GameObject PlayerPrefab;
    public override void InstallBindings()
    {
        BindPlayer();
    }

    private void BindPlayer()
    {
        PlayerView playerView = Container
            .InstantiatePrefabForComponent<PlayerView>(PlayerPrefab, PlayerSpawnPoint.position, Quaternion.identity, null);

        Container
            .Bind<PlayerView>()
            .FromInstance(playerView)
            .AsSingle()
            .NonLazy();
        Container
            .BindInterfacesTo<FPSInput>()
            .AsSingle()
            .NonLazy();
        Container
            .BindInterfacesTo<MouseLook>()
            .AsSingle()
            .NonLazy();
    }
}
