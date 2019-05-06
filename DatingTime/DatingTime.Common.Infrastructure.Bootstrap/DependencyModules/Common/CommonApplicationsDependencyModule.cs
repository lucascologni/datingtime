using DatingTime.Common.Applications.Security.Commands.PasswordEncryption;
using DatingTime.Common.Applications.Security.Models;
using DatingTime.Common.Infrastructure.DependencyResolver;
using MediatR;

namespace DatingTime.Common.Infrastructure.Bootstrap.DependencyModules.Common
{
    public class CommonApplicationsDependencyModule : IDependencyModule
    {
        public void Register()
        {
            IoC.RegisterTransient<IRequestHandler<PasswordEncryptionCommand, PasswordEncryptionDto>, PasswordEncryptionHandler>();
        }
    }
}