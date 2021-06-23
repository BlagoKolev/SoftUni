using CarShop.Models.Users;

namespace CarShop.Services
{
    public interface IUserService
    {
        bool IsMechanic(string userId);
        void CreateUser(RegisterUserFormModel model);
        string CheckUser(LoginUserFormModel model);
    }
}
