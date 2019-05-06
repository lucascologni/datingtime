using DatingTime.Accounts.Domain.Interfaces.Services;
using DatingTime.Accounts.Domain.Services;
using DatingTime.Common.Infrastructure.DependencyResolver;

namespace DatingTime.Common.Infrastructure.Bootstrap.DependencyModules.Accounts
{
    public class AccountsDomainDependencyModule : IDependencyModule
    {
        public void Register()
        {
            IoC.RegisterTransient<IAccountService, AccountService>();
        }
    }
}