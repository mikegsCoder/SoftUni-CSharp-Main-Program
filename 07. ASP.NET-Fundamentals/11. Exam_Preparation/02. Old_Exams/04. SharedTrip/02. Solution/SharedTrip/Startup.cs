namespace SharedTrip
{
    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;

    using MyWebServer.Results.Views;
    using SharedTrip.Data;
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Data.Common;
    using SharedTrip.Services.UserService;
    using SharedTrip.Services.ValidationService;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<ApplicationDbContext>()
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IRepository, Repository>()
                    .Add<IValidationService, ValidationService>()
                    .Add<IUserService, UserService>())
                    .WithConfiguration<ApplicationDbContext>(context => context
                        .Database.Migrate())
                .Start();
    }
}
