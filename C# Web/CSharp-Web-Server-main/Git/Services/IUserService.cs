using Git.Data.Models;
using Git.Models.Users;


namespace Git.Services
{
    public interface IUserService
    {
        void CreateUser(RegisterFormViewModel model);
        string LoginUser(LoginFormViewModel model);
    }
}
