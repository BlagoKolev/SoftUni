using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sets_and_Dictionaries_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var listOfNames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                listOfNames.Add(name);
            }

            foreach (var name in listOfNames)
            {
                Console.WriteLine(name);
            }

        }
    }
}
