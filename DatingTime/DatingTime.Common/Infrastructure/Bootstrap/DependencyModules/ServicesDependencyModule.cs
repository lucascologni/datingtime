using DatingTime.Common.Infrastructure.DependencyResolver;

namespace DatingTime.Common.Infrastructure.Bootstrap.DependencyModules
{
    public class ServicesDependencyModule : IDependencyModule
    {
        public void Register()
        {
            IoC.RegisterSingleton<IMediator, Mediator>();
        }
    }
}