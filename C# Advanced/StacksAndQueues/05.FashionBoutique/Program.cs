using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rackCapacity = int.Parse(Console.ReadLine());

            var box = new Stack<int>(clothes);

            var sumOfClothes = 0;
            var racksCount = 1;

            while (box.Any())
            {
                var peekClothes = box.Peek();

                if (sumOfClothes + peekClothes <= rackCapacity)
                {
                    sumOfClothes += peekClothes;
                    box.Pop();
                }
                else
                {
                    sumOfClothes = 0;
                    racksCount++;
                    sumOfClothes += peekClothes;
                    box.Pop();

                }
            }

            Console.WriteLine(racksCount);
        }
    }
}
