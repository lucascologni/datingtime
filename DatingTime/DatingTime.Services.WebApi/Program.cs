﻿using DatingTime.Services.Api;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DatingTime.Services.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
    //comentario teste ary
}