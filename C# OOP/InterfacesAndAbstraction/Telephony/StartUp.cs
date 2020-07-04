using System;

namespace Telephony
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var phoneNumbers = Console.ReadLine().Split();
            var url = Console.ReadLine().Split();
            var smartPhone = new Smartphone();
            var stationaryPhone = new StationaryPhone();
            foreach (var phone in phoneNumbers)
            {
                try
                {
                    if (phone.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Calling(phone));
                    }
                    else if (phone.Length == 10)
                    {
                        Console.WriteLine(smartPhone.Calling(phone));
                    }
                    else
                    {
                        throw new ArgumentException(Exceptions.InvalidPhoneException);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    continue;
                }

            }
            foreach (var adress in url)
            {
                try
                {
                    Console.WriteLine(smartPhone.Browse(adress));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    continue;
                }

            }
        }
    }
}
