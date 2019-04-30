using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DatingTime.Services.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            // Cria um 'Servidor Web' padrão usando 'Kestrel' (Como IIS ou Tomcat).
            WebHost.CreateDefaultBuilder(args)
                // O projeto irá utilizar a classe 'Startup', onde possui todos os métodos iniciais para a construção da aplicação.
                .UseStartup<Startup>();
    }
}