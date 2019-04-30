using DatingTime.Domain.Interfaces.Repositories;
using DatingTime.Infrastructure.Data.Sql.Repositories;
using DatingTime.Infrastructure.DependencyResolver;

namespace DatingTime.Infrastructure.Bootstrap.DependencyModules
{
    public class InfrastructureDependencyModule : IDependencyModule
    {
        public void Register()
        {
            IoC.RegisterTransient<IAccountRepository, AccountRepository>();
        }
    }
}