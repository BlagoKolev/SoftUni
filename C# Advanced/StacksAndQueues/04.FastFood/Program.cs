using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            var foodAmount = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var myQueue = new Queue<int>(orders);
            Console.WriteLine(myQueue.Max());
            for (int i = 0; i < orders.Length; i++)
            {
                var currentOrder = myQueue.Peek();
                if (currentOrder <= foodAmount)
                {
                    foodAmount -= currentOrder;
                    myQueue.Dequeue();
                }
                else
                {
                    Console.Write("Orders left: ");
                    Console.WriteLine(string.Join(" ", myQueue));
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }
    }
}
