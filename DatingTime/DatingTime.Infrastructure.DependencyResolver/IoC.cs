using SimpleInjector;

namespace DatingTime.Infrastructure.DependencyResolver
{
    public static class IoC
    {
        private static readonly Container Container;

        static IoC()
        {
            Container = new Container();
        }

        public static Container RecoverContainer() => Container;

        public static void RegisterTransient<TInt, TImp>()
            where TImp : class, TInt
            where TInt : class
        {
            Container.Register<TInt, TImp>(Lifestyle.Transient);
        }

        public static void RegisterSingleton<TInt, TImp>()
            where TImp : class, TInt
            where TInt : class
        {
            Container.RegisterSingleton<TInt, TImp>();
        }

        public static void RegisterModule<TModule>()
            where TModule : IDependencyModule, new()
        {
            new TModule().Register();
        }
    }
}