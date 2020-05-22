using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_12.Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var cupsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var bottlesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var cups = new Queue<int>(cupsInput);
            var bottles = new Stack<int>(bottlesInput);
            var wasterWater = 0;

            while (cups.Any() && bottles.Any())
            {
                var currentBottle = bottles.Pop();
                var currentCup = cups.Peek();
                if (currentCup > currentBottle)
                {
                    while (true)
                    {
                        currentCup = currentCup - currentBottle;

                        if (currentCup <= 0)
                        {
                            break;
                        }
                        currentBottle = bottles.Pop();
                    }
                }
                else
                {
                    currentCup -= currentBottle;

                }
                if (currentCup <= 0)
                {
                    cups.Dequeue();
                    wasterWater += Math.Abs(currentCup);
                }
            }
            if (!bottles.Any())
            {
                Console.WriteLine("Cups: {0}", string.Join(" ", cups));
            }
            else if (!cups.Any())
            {
                Console.WriteLine("Bottles: {0}", string.Join(" ", bottles));
            }
            Console.WriteLine("Wasted litters of water: {0}", wasterWater);
        }
    }
}
