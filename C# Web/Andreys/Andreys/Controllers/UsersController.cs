using Andreys.Models.Users;
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

    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly IUserService userService;
        public UsersController(IValidator validator, IPasswordHasher passwordHasher, IUserService userService)
        {
            this.validator = validator;
            this.passwordHasher = passwordHasher;
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
               return this.Redirect("/Users/Register");
            }

            var checkUser = userService.CheckUserExists(model);

            if (checkUser != null)
            {
                return Error("User already exist.");
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
            var userId = userService.LogUser(model);

            if (userId == null)
            {
                return this.Redirect("Users/Login");
            }

            this.SignIn(userId);

            return this.Redirect("/Home");


        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
