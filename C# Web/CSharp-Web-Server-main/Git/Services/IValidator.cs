namespace Git.Services
{
    using Git.Models.Users;
    using System.Collections.Generic;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterFormViewModel model);
     
    }
}
