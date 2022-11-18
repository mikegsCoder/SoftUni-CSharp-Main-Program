using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using SMS.Data;
using SMS.Data.Common;
using SMS.Services.CartService;
using SMS.Services.ProductService;
using SMS.Services.UserService;
using SMS.Services.ValidationService;

namespace SMS
{
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
                    .Add<IRepository, Repository>()
                    .Add<IValidationService, ValidationService>()
                    .Add<IUserService, UserService>()
                    .Add<IProductService, ProductService>()
                    .Add<ICartService, CartService>())
                    .WithConfiguration<SMSDbContext>(context => context
                        .Database.Migrate())
                .Start();
    }
}