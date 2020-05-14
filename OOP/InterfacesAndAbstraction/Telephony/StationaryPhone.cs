using System;
using Telephony.Exceptions;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
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
            sb.Append(String.Format($"Dialing... {number}"));
            return sb.ToString();

        }
    }
}
