using DatingTime.Accounts.Applications.AccountManagement.Commands.AccountManagement;
using DatingTime.Accounts.Applications.AccountManagement.Models;
using DatingTime.Common.Infrastructure.DependencyResolver;
using MediatR;

namespace DatingTime.Common.Infrastructure.Bootstrap.DependencyModules.Accounts
{
    public class AccountsApplicationsDependencyModule : IDependencyModule
    {
        public void Register()
        {
            IoC.RegisterTransient<IRequestHandler<AccountManagementCommand, AccountRegistrationDto>, AccountManagementHandler>();
        }
    }
}