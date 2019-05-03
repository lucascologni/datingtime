using DatingTime.Common.Infrastructure.DependencyResolver;

namespace DatingTime.Common.Infrastructure.Bootstrap.DependencyModules
{
    public class InfrastructureDependencyModule : IDependencyModule
    {
        public void Register()
        {
           // IoC.RegisterTransient<IAccountRepository, AccountRepository>();
        }
    }
}