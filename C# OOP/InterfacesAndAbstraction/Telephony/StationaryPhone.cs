using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Calling(string number)
        {
            foreach (var symbol in number)
            {
                if (!char.IsDigit(symbol))
                {
                    throw new ArgumentException(Exceptions.InvalidPhoneException);
                }
            }
            return string.Format($"Dialing... {number}");
        }
    }
}
