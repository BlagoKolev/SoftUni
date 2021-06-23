namespace CarShop.Services
{
    using System.Linq;
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.Models.Users;

    public class UserService : IUserService
    {
        private readonly CarShopDbContext db;
        private readonly IPasswordHasher passwordHasher;

        public UserService(CarShopDbContext db, IPasswordHasher passwordHasher)
        {
            this.db = db;
            this.passwordHasher = passwordHasher;
        }

        public string CheckUser(LoginUserFormModel model)
        {
            var hashedPass = passwordHasher.HashPassword(model.Password);

            var userId = this.db.Users
                .Where(u => u.Username == model.Username && u.Password == hashedPass)
                .Select(u => u.Id)
                .FirstOrDefault();
            return userId;
        }

        public void CreateUser(RegisterUserFormModel model)
        {
            var hashedPass = passwordHasher.HashPassword(model.Password);

            var newUser = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = hashedPass,
                IsMechanic = model.UserType == "Mechanic"
            };
            this.db.Users.Add(newUser);
            this.db.SaveChanges();
        }

        public bool IsMechanic(string userId)
            => this.db
                .Users
                .Any(u => u.Id == userId && u.IsMechanic);
    }
}
