using DatingTime.Common.Infrastructure.DependencyResolver;

namespace DatingTime.Common.Infrastructure.Bootstrap.DependencyModules
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