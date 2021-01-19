using System;
using System.Linq;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            BubbleSorting(array);
            Console.WriteLine(string.Join(' ', array));
        }
        static int[] BubbleSorting(int[] array)
        {
            var isSorted = true;
            for (int i = 0; i < array.Length; i++)
            {

                for (int j = 1; j < array.Length - i; j++)
                {
                    if (array[j - 1] > array[j])
                    {
                        isSorted = false;
                        Swap(array, array[j - 1], array[j]);
                    }
                   // Console.WriteLine(string.Join(' ', array));
                }
                if (isSorted)
                {
                    break;
                }
            }
            return array;
        }
        static void Swap(int[] array, int first, int second)
        {
            var firstIndex = Array.IndexOf(array, first);
            var secondIndex = Array.IndexOf(array, second);
            array[firstIndex] = second;
            array[secondIndex] = first;
        }
    }
}
