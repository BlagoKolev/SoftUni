using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var elementsCount = input[0];
            var elementsToRemove = input[1];
            var searchedNumber = input[2];
            var numbersToDequeue = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var myQueue = new Queue<int>();

            for (int i = 0; i < elementsCount; i++)
            {
                var currentElement = numbersToDequeue[i];
                myQueue.Enqueue(currentElement);
            }

            for (int i = 0; i < elementsToRemove; i++)
            {
                if (myQueue.Any())
                {
                    myQueue.Dequeue();
                }
            }


            if (!myQueue.Any())
            {
                Console.WriteLine(0);
                return;
            }
            if (myQueue.Contains(searchedNumber))
            {
                Console.WriteLine("true");
            }

            else
            {
                Console.WriteLine(myQueue.Min());
            }

        }
    }
}


