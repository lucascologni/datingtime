using DatingTime.Domain.Generators;
using DatingTime.Domain.Interfaces.Generators;
using DatingTime.Domain.Interfaces.Services;
using DatingTime.Domain.Services;
using DatingTime.Infrastructure.DependencyResolver;

namespace DatingTime.Infrastructure.Bootstrap.DependencyModules
{
    public class DomainDependencyModule : IDependencyModule
    {
        public void Register()
        {
            IoC.RegisterTransient<IAccountService, AccountService>();
            IoC.RegisterTransient<IPasswordHashGenerator, PasswordHashGenerator>();
        }
    }
}