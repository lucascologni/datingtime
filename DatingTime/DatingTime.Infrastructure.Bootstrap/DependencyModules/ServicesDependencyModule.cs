using DatingTime.Infrastructure.DependencyResolver;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingTime.Infrastructure.Bootstrap.DependencyModules
{
    public class ServicesDependencyModule : IDependencyModule
    {
        public void Register()
        {
            IoC.RegisterSingleton<IMediator, Mediator>();
        }
    }
}