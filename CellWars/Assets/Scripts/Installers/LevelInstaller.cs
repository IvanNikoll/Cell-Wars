using Zenject;

public class LevelInstaller : MonoInstaller
{
    
    public override void InstallBindings()
    {
        Container.Bind<LevelBootstrap>().FromComponentInHierarchy().AsSingle();
        Container.Bind<CellSpawner>().FromComponentInHierarchy().AsSingle();
        Container.Bind<LevelContext>().FromComponentInHierarchy().AsSingle();
        Container.Bind<LevelConfigProvider>().FromComponentInHierarchy().AsSingle();
    }
}
