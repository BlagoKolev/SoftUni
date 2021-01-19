using System;
using System.Linq;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var resultArray = SelectionSorting(array);
            Console.WriteLine(string.Join(" ", array));
        }
        static int[] SelectionSorting(int[] array)
        {

            for (int i = 0; i < array.Length - 1; i++)
            {
            var minElement = int.MaxValue;
                var currentElement = array[i];
                var isSmaller = false;

                for (int j = i + 1; j < array.Length; j++)
                {
                    var nextElement = array[j];
                   
                    if (currentElement > nextElement)
                    {
                        isSmaller = true;
                        if (minElement >= nextElement)
                        {
                            minElement = nextElement;
                        }
                    }
                }
                if (isSmaller)
                {
                    var currentIndex = Array.IndexOf(array, currentElement);
                    var minIndex = Array.IndexOf(array, minElement);
                    array[minIndex] = currentElement;
                    array[currentIndex] = minElement;
                }

            }

            return array;
        }
    }
}
