using Andreys.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreys.Services
{
    public interface IUserService
    {
        void CreateUser(RegisterUserFormModel model);
        string CheckUserExists(RegisterUserFormModel model);
        string LogUser(LoginUserFormModel model);
    }
}
