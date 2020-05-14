using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Exceptions
{
    public class InvalidPhoneException : Exception
    {
        private const string EXC_MESSAGE = "Invalid number!";
        public InvalidPhoneException()
            :base(EXC_MESSAGE)
        {
        }

        public InvalidPhoneException(string message) : base(message)
        {
        }
    }
}
