using Andreys.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreys.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;
        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }
        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Home/Home");
            }
            return this.View();
        }

        [Authorize]
        public HttpResponse Home()
        {

            if (this.User.IsAuthenticated)
            {
                var products = homeService.GetAllProducts();
                return this.View(products);
            }

            return Unauthorized();
        }

    }
}
