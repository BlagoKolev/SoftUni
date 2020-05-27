using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var myDictionary = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                var number = int.Parse(Console.ReadLine());

                if (!myDictionary.ContainsKey(number))
                {
                    myDictionary[number] = 0;
                }
                myDictionary[number] += 1;
            }
            foreach (var number in myDictionary.Where(x => x.Value % 2 == 0))
            {
                Console.WriteLine(number.Key);
            }
        }
    }
}
