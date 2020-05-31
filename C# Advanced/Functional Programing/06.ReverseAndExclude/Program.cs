using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var divideTo = int.Parse(Console.ReadLine());

            Func<List<int>,List<int>> result = ReverseCollection(input, divideTo);

            Console.WriteLine(string.Join(" ",result(input)));

        }
        static Func<List<int>, List<int>> ReverseCollection(List<int> myList, int n)
        {
            var result = new List<int>();

            myList.Reverse();

            Func<List<int>, List<int>> transform = new Func<List<int>, List<int>>((myList) =>
            {
                for (int i = 0; i < myList.Count; i++)
                {
                    if (myList[i] % n != 0)
                    {
                        result.Add(myList[i]);
                    }
                }
                return result;
            });

            return transform;
        }
    }
}
