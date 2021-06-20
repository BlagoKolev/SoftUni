using Git.Models;
using Git.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Controllers
{
   public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IUserService userService;
        public UsersController(IValidator validator, IUserService userService)
        {
            this.validator = validator;
            this.userService = userService;
        }
        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterFormViewModel model)
        {
            var modelErrors = validator.ValidateUser(model);
            if (modelErrors.Any())
            {
                Error(modelErrors);
            }
            userService.CreateUser(model);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            return this.View();
        }
    }
}
