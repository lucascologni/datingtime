using DatingTime.Applications.Account.Commands.AccountRegistration;
using DatingTime.Applications.Account.Models;
using DatingTime.Applications.Security.Commands.PasswordEncryption;
using DatingTime.Applications.Security.Models;
using DatingTime.Applications.Security.Requests.Commands.PasswordEncryption;
using DatingTime.Infrastructure.DependencyResolver;
using MediatR;

namespace DatingTime.Infrastructure.Bootstrap.DependencyModules
{
    public class ApplicationsDependencyModule : IDependencyModule
    {
        public void Register()
        {
            IoC.RegisterTransient<IRequestHandler<PasswordEncryptionCommand, PasswordEncryptionDto>, PasswordEncryptionHandler>();
            IoC.RegisterTransient<IRequestHandler<AccountRegistrationCommand, AccountRegistrationDto>, AccountRegistrationHandler>();
        }
    }
}