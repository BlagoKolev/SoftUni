using Andreys.Data;
using Andreys.Data.Models;
using Andreys.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreys.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext db;
        private readonly IPasswordHasher paswwordHasher;

        public UserService(AppDbContext db, IPasswordHasher paswwordHasher)
        {
            this.db = db;
            this.paswwordHasher = paswwordHasher;
        }
        public void CreateUser(RegisterUserFormModel model)
        {
            var hashedPassword = paswwordHasher.HashPassword(model.Password);
            var newUser = new User
            {
                Username = model.Username,
                Password = hashedPassword,
                Email = model.Email
            };
            this.db.Users.Add(newUser);
            this.db.SaveChanges();

        }

        public string CheckUserExists(RegisterUserFormModel model)
        {
            var userId = this.db.Users
                     .Where(u => u.Email != model.Email && u.Username != model.Username)
                 .Select(u => u.Id).FirstOrDefault();
            return userId;
        }

        public string LogUser(LoginUserFormModel model)
        {
            var hashedPassword = paswwordHasher.HashPassword(model.Password);

            var userId = this.db.Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();
            return userId;
        }
    }
}
