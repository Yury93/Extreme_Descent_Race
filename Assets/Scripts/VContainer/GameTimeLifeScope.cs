using VContainer;
using VContainer.Unity;

public class GameTimeLifeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        //builder.RegisterInstance(GameObject2).WithParameter(Lifetime.Singleton);
        //builder.Register<VContainerLoop>(Lifetime.Singleton).AsImplementedInterfaces();
    }
}
