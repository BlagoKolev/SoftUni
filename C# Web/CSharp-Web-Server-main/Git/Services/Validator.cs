using Git.Models.Users;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Git.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterFormViewModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < 4 || model.Username.Length > 20)
            {
                errors.Add("Username must be between 4 and 20 characters");
            }
            if (model.Password.Length < 5 || model.Password.Length > 20)
            {
                errors.Add("Password must be between 5 and 20 characters");
            }
            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("'Password' and 'Confirm Password' fields must be same");
            }
            
            return errors;
        }

    
    }
}
