using BattleCards.Data;
using BattleCards.Data.Models;
using BattleCards.Models.Users;
using BattleCards.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly AppDbContext db;
        public UsersController(IValidator validator, IPasswordHasher passwordHasher, AppDbContext db)
        {
            this.passwordHasher = passwordHasher;
            this.validator = validator;
            this.db = db;
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

            var hashedPassword = passwordHasher.HashPassword(model.Password);

            var newUser = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = hashedPassword,
            };

            db.Users.Add(newUser);
            db.SaveChanges();
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel model)
        {
            var hashedPassword = passwordHasher.HashPassword(model.Password);

            var loginUserId = db.Users
                .Where(u => u.Username == model.Username
                && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (loginUserId == null)
            {
                return Error("Wrong username or password.");
            }

            SignIn(loginUserId);
            return this.Redirect("/Cards/All");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
