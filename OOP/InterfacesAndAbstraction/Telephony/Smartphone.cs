using System;
using Telephony.Exceptions;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public Smartphone() { }

        public string Browse(string text)
        {

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    throw new InvalidURLException();
                }
            }

            var sb = new StringBuilder();
            sb.Append(String.Format($"Browsing: {text}!"));
            return sb.ToString();
        }

        public string Call(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    throw new InvalidPhoneException();
                }
            }
            var sb = new StringBuilder();
            sb.Append(String.Format($"Calling... {number}"));
            return sb.ToString();

        }
    }
}
