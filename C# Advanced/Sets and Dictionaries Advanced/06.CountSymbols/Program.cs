using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var myDictionary = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                var symbol = text[i];

                if (!myDictionary.ContainsKey(symbol))
                {
                    myDictionary[symbol] = 0;
                }
                myDictionary[symbol] += 1;
            }

            foreach (var symbol in myDictionary)
            {
                Console.WriteLine("{0}: {1} time/s", symbol.Key, symbol.Value);
            }
        }
    }
}
