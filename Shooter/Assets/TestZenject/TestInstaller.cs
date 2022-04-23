using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<string>().FromInstance("Hello World!");
        Container.Bind<Test>().AsSingle().NonLazy();
    }
}

public class Test
{
    public Test(string message)
    {
        Debug.Log(message);
    }
}