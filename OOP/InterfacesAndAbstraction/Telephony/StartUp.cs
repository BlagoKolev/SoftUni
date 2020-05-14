using System;
using Telephony.Exceptions;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var numberArgs = Console.ReadLine().Split();
            var urlArgs = Console.ReadLine().Split();
            var smartphone = new Smartphone();
            var stationaryPhone = new StationaryPhone();

            foreach (var number in numberArgs)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(number));
                    }
                    else if (number.Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(number));
                    }
                    else
                    {
                        throw new InvalidPhoneException();
                    }
                }
                catch (InvalidPhoneException ice )
                {
                    Console.WriteLine(ice.Message);
                }
               
            }

            foreach (var url in urlArgs)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (InvalidURLException iue)
                {
                    Console.WriteLine(iue.Message);
                }
               
            }


        }
    }
}
