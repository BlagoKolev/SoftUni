using BattleCards.Models.Cards;
using BattleCards.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BattleCards.Services
{

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel user)
        {
            var errors = new List<string>();

            if (user.Username == null || user.Username.Length < 5 || user.Username.Length > 15)
            {
                errors.Add($"Username '{user.Username}' is not valid. It must be between 5 and 15 characters long.");
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

        public ICollection<string> ValidateCard(AddCardsFormModel card)
        {
            var errors = new List<string>();

            if (card.Name == null || card.Name.Length < 5 || card.Name.Length > 15)
            {
                errors.Add($"Model '{card.Name}' is not valid. It must be between 5 and 15 characters long.");
            }

            if (card.Description.Length > 200)
            {
                errors.Add($"Year '{card.Description}' is not valid. It must mode than 200 characters.");
            }

            if (card.Image == null || !Uri.IsWellFormedUriString(card.Image, UriKind.Absolute))
            {
                errors.Add($"Image '{card.Image}' is not valid. It must be a valid URL.");
            }

            if (card.Keyword == null)
            {
                errors.Add($"'{card.Keyword}' is not valid.");
            }
            if (card.Attack == null || card.Attack < 0)
            {
                errors.Add($"'Attack' is not valid.");
            }

            if (card.Health == null || card.Health < 0)
            {
                errors.Add($"'Health' is not valid.");
            }

            return errors;
        }

    }
}


