﻿namespace SMS
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using SMS.Data;
    using SMS.Data.Common;

    public class StartUp
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<SMSDbContext>()
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IRepository, Repository>())
                    .WithConfiguration<SMSDbContext>(context => context
                        .Database.Migrate())
                .Start();
    }
}