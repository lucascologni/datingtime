using DatingTime.Common.Domain.Interfaces.Generators;
using DatingTime.Common.Infrastructure.DependencyResolver;
using DatingTime.Domain.Generators;

namespace DatingTime.Common.Infrastructure.Bootstrap.DependencyModules.Common
{
    public class CommonDomainDependencyModule : IDependencyModule
    {
        public void Register()
        {
            IoC.RegisterTransient<IPasswordHashGenerator, PasswordHashGenerator>();
        }
    }
}