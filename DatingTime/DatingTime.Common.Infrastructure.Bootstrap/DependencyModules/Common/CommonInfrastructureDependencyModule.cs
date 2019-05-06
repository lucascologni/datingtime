using DatingTime.Common.Infrastructure.DependencyResolver;

namespace DatingTime.Common.Infrastructure.Bootstrap.DependencyModules.Common
{
    public class CommonInfrastructureDependencyModule : IDependencyModule
    {
        public void Register()
        {
           // IoC.RegisterTransient<IAccountRepository, AccountRepository>();
        }
    }
}