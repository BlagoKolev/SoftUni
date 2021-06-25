using Andreys.Data;
using Andreys.Services;
using Microsoft.EntityFrameworkCore;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using System;
using System.Threading.Tasks;

namespace Andreys
{
    class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                .Add<AppDbContext>()
                .Add<IViewEngine, CompilationViewEngine>()
                .Add<IValidator, Validator>()
                .Add<IPasswordHasher, PasswordHasher>()
               .Add<IUserService, UserService>()
                .Add<IHomeService, HomeService>()
                .Add<IProductService,ProductService>()
                )
            .WithConfiguration<AppDbContext>(context => context.Database.EnsureCreated())
                .Start();

    }
}
