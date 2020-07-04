using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ICallable
    {
        public string Calling(string number);
    }
}
