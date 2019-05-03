using System;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using DatingTime.Common.Infrastructure.Bootstrap.DependencyModules;
using DatingTime.Common.Infrastructure.DependencyResolver;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Configuration;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;

namespace DatingTime.Services.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly Container _container;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            _container = IoC.RecoverContainer();
        }

        // Configuração dos serviços do projeto.
        public void ConfigureServices(IServiceCollection services)
        {
            // Adiciona o serviço do "MVC".
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Adiciona o serviço do framework ORM "Entity Framework" na aplicação.
            // A "ConnectionString" está localizada no arquivo "appsettings.json"
            //services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            // Adiciona o serviço do "CORS" (Cross-Origin Resource Sharing) - Medida de segurança que permite restringir acesso de algum Client(Angular App) que está tentando acessar a API.
            // Acesso Cruzado - Uma aplicação hospedada em um endereço diferente acessando uma API de outro endereço.
            services.AddCors();



            // Adiciona o serviço de mapeamento de objetos utilizando o "Auto Mapper".
            //services.AddAuto();

            // Adiciona o serviço de injeção de dependência utilizando o "Simple Injector".
            AddSimpleInjector(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Verifica se o ambiente é de desenvolvimento.
            if (env.IsDevelopment())
            {
                // A aplicação vai tratar e utilizar a página de exceção global de desenvolvimento. 
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseMvc();

            // SI - Simple Injector
            InitializeSIContainer(app);
        }

        private void AddSimpleInjector(IServiceCollection services)
        {
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(_container));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(_container));

            services.EnableSimpleInjectorCrossWiring(_container);
            services.UseSimpleInjectorAspNetRequestScoping(_container);
        }

        private void InitializeSIContainer(IApplicationBuilder app)
        {
            // Add application presentation components:
            _container.RegisterMvcControllers(app);
            _container.RegisterMvcViewComponents(app);

            // Allow Simple Injector to resolve services from ASP.NET Core.
            _container.AutoCrossWireAspNetComponents(app);

            // Registra os módulos do sistema.
            IoC.RegisterModule<ServicesDependencyModule>();
            IoC.RegisterModule<ApplicationsDependencyModule>();
            IoC.RegisterModule<DomainDependencyModule>();
            IoC.RegisterModule<InfrastructureDependencyModule>();

            RegisterMediatRResourcesIntoSimpleInjector();
        }

        private void RegisterMediatRResourcesIntoSimpleInjector()
        {
            // Recupera o Container do Simple Injector.
            var simpleInjectorContainer = IoC.RecoverContainer();

            /* Registra o Service Factory do MediatR no Container do Simple Injector, com isso o MediatR consegue resolver as dependências
             * utilizando as mesmas definições do Simple Injector.
             */
            simpleInjectorContainer.Register(() => new ServiceFactory(simpleInjectorContainer.GetInstance), Lifestyle.Singleton);

            // É necessário especificar uma definição para o PipelineBehavior, IRequestPreProcessor e IRequestPostProcessor pois não pode ser vazio.
            simpleInjectorContainer.Collection.Register(typeof(IPipelineBehavior<,>), Enumerable.Empty<Type>());
            simpleInjectorContainer.Collection.Register(typeof(IRequestPreProcessor<>), Enumerable.Empty<Type>());
            simpleInjectorContainer.Collection.Register(typeof(IRequestPostProcessor<,>), Enumerable.Empty<Type>());

            simpleInjectorContainer.RegisterSingleton(() => GetMapper(simpleInjectorContainer));
        }

        public IMapper GetMapper(Container container)
        {
            var mce = new MapperConfigurationExpression();
            mce.ConstructServicesUsing(container.GetInstance);

            // Classes - ENTITY TO DTO, DTO TO ENTITY
            // mce.AddProfiles(typeof(SomeProfile).Assembly);
            // mce.AddProfiles(typeof(SomeProfile).Assembly);
            // mce.AddProfiles(typeof(SomeProfile).Assembly);
            // mce.AddProfiles(typeof(SomeProfile).Assembly);

            var mc = new MapperConfiguration(mce);
            mc.AssertConfigurationIsValid();

            IMapper m = new Mapper(mc, t => container.GetInstance(t));

            return m;
        }
    }
}