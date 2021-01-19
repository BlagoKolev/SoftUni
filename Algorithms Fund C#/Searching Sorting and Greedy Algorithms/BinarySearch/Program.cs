using System;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine()
     .Split()
     .Select(int.Parse)
     .ToArray();

            var searchedNumber = int.Parse(Console.ReadLine());

            var result = BinarySearch(array, searchedNumber);
            Console.WriteLine(result);
        }
        static int BinarySearch(int[] array, int number)
        {
            var startIndex = 0;
            var endIndex = array.Length - 1;

            while (startIndex <= endIndex)
            {
                var pointer = (endIndex + startIndex) / 2;

                if (array[pointer] == number)
                {
                    return pointer;
                }
                else if (array[pointer] < number)
                {
                    startIndex = pointer + 1;
                }
                else if (array[pointer] > number)
                {
                    endIndex = pointer-1;
                }
            }
            return -1;
        }
    }
}
