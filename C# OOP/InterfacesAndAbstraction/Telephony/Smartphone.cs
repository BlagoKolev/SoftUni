using System;


namespace Telephony
{
    public class Smartphone : ICallable, IBrowseable
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
          return string.Format($"Calling... {number}");
        }
        public string Browse(string URL)
        {
            foreach (var symbol in URL)
            {
                if (char.IsDigit(symbol))
                {
                    throw new ArgumentException(Exceptions.InvalidURLException);
                }
            }
            return $"Browsing: {URL}!";
            
        }

       
    }
}
