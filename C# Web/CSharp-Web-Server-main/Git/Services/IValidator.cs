namespace Git.Services
{
    using Git.Models;
    using System.Collections.Generic;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterFormViewModel model);
     
    }
}
