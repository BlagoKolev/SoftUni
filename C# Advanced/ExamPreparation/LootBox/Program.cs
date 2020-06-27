using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstBox = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondBox = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var claimedItems = 0;

            var firstBoxQueue = new Queue<int>(firstBox);
            var secondBoxStack = new Stack<int>(secondBox);

            while (firstBoxQueue.Any() && secondBoxStack.Any())
            {
                var first = firstBoxQueue.Peek();
                var second = secondBoxStack.Peek();

                if ((first + second) % 2 == 0)
                {
                    var sum = first + second;
                    claimedItems += sum;
                    firstBoxQueue.Dequeue();
                    secondBoxStack.Pop();
                }
                else
                {
                    second = secondBoxStack.Pop();
                    firstBoxQueue.Enqueue(second);
                }
            }

            if (!firstBoxQueue.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            if (!secondBoxStack.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (claimedItems >= 100)
            {
                Console.WriteLine("Your loot was epic! Value: {0}", claimedItems);
            }
            else
            {
                Console.WriteLine("Your loot was poor... Value: {0}", claimedItems);
            }

        }
    }
}
