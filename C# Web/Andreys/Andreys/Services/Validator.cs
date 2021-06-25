using Andreys.Models.Products;
using Andreys.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Andreys.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateProduct(AddProductsFormModel model)
        {
            var errors = new List<string>();

            if (model.Name == null || model.Name.Length < 4 || model.Name.Length > 20)
            {
                errors.Add("Name must be between 4 and 20 characters.");
            }
            if (model.Description.Length > 10)
            {
                errors.Add("Description must be less than 10 characters.");
            }
            if (model.Price == null)
            {
                errors.Add("Price can not be null");
            }
            if (model.Category == null || model.Category !=  "Shirt"
                && model.Category != "Denim"
                &&model.Category != "Shorts"
                && model.Category != "Jacket")
            {
                errors.Add("Invalid Category type");
            }
            if (model.Gender == null
                || model.Gender !="Male"
                && model.Gender != "Female")
            {
                errors.Add("Invalid gender type");
            }
            return errors;
        }

        public ICollection<string> ValidateUser(RegisterUserFormModel user)
        {
            var errors = new List<string>();

            if (user.Username == null || user.Username.Length < 5 || user.Username.Length > 15)
            {
                errors.Add($"Username '{user.Username}' is not valid. It must be between 4 and 10 characters long.");
            }

            if (user.Email == null || !Regex.IsMatch(user.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                errors.Add($"Email '{user.Email}' is not a valid e-mail address.");
            }

            if (user.Password == null || user.Password.Length < 6 || user.Password.Length > 20)
            {
                errors.Add($"The provided password is not valid. It must be between 6 and 20 characters long.");
            }

            if (user.Password != null && user.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (user.Password != user.ConfirmPassword)
            {
                errors.Add("Password and its confirmation are different.");
            }


            return errors;
        }
    }
}
