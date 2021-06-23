using CarShop.Models.Users;
using CarShop.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IUserService userService;
        public UsersController(IValidator validator,IUserService userService)
        {
            this.validator = validator;
            this.userService = userService;
        }
        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var modelErrors = validator.ValidateUser(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }
            
            userService.CreateUser(model);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel model)
        {
            var userId = userService.CheckUser(model);
            if (userId == null)
            {
                return Error("Wrong 'Username' or 'Password'.");
            }

            SignIn(userId);
            return this.Redirect("/Cars/All");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
