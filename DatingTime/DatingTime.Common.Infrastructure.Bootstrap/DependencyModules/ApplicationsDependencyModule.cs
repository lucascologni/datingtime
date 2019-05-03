using DatingTime.Common.Infrastructure.DependencyResolver;

namespace DatingTime.Common.Infrastructure.Bootstrap.DependencyModules
{
    public class ApplicationsDependencyModule : IDependencyModule
    {
        public void Register()
        {
          //  IoC.RegisterTransient<IRequestHandler<PasswordEncryptionCommand, PasswordEncryptionDto>, PasswordEncryptionHandler>();
            //IoC.RegisterTransient<IRequestHandler<AccountRegistrationCommand, AccountRegistrationDto>, AccountRegistrationHandler>();
        }
    }
}