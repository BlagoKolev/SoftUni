using Git.Data;
using Git.Data.Models;
using Git.Models;
using Git.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;
        private readonly IPasswordHasher passwordHasher;

        public UserService(ApplicationDbContext db, IPasswordHasher passwordHasher)
        {
            this.db = db;
            this.passwordHasher = passwordHasher;
        }

        public void CreateUser(RegisterFormViewModel model)
        {
            var hashedPassword = passwordHasher.HashPassword(model.Password);

            var newUser = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = hashedPassword
            };

            db.Users.Add(newUser);
            db.SaveChanges();
        }

       
        public string LoginUser(LoginFormViewModel model)
        {
            var hashedPassword = passwordHasher.HashPassword(model.Password);
            var user = db.Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .FirstOrDefault();
            return user.Id;
        }
    }
}
