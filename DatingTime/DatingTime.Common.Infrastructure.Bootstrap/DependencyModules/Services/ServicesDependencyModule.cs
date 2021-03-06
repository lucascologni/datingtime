﻿using DatingTime.Common.Infrastructure.DependencyResolver;
using MediatR;

namespace DatingTime.Common.Infrastructure.Bootstrap.DependencyModules.Services
{
    public class ServicesDependencyModule : IDependencyModule
    {
        public void Register()
        {
            IoC.RegisterSingleton<IMediator, Mediator>();
        }
    }
}