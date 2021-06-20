using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class HomeController : Controller
    {
        [HttpGet()]
        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Repositories/All");
            }

            return this.View();
        }
    }
}
