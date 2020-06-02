using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var result = new List<int>();

            Func<int[], List<int>> DivideNumbers = (x =>
            {
                for (int i = 1; i <= n; i++)
                {
                    var canDivideTo = true;

                    for (int j = 0; j < dividers.Length; j++)
                    {
                        if (i % dividers[j] != 0)
                        {
                            canDivideTo = false;
                            break;
                        }

                    }
                    if (canDivideTo == true)
                    {
                        result.Add(i);
                    }
                }
                return result;
            });
            Console.WriteLine(string.Join(" ", DivideNumbers(dividers)));
        }
    }
}
