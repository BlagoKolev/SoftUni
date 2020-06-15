using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubParty
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var maxCapacity = int.Parse(Console.ReadLine());

            var input = Console.ReadLine().Split();
            var reservations = new Stack<string>(input);
            var sb = new StringBuilder();
            var sum = 0;
            var hall = new Queue<string>();
            var hallsGuest = new List<int>();

            var currentHall = string.Empty;

            while (reservations.Any())
            {
                var currentElement = reservations.Peek();
                var number = 0;
                var isNumber = int.TryParse(currentElement, out number);

                if (!isNumber)
                {
                    currentHall = currentElement;
                    hall.Enqueue(currentHall);
                    reservations.Pop();

                    continue;
                }
                else
                {
                    if (hall.Count == 0)
                    {
                        reservations.Pop();
                        continue;
                    }
                    if (sum + number <= maxCapacity)
                    {
                        sum += number;
                        hallsGuest.Add(number);
                        reservations.Pop();
                    }
                    else
                    {
                        Console.WriteLine("{0} -> " + string.Join(", ", hallsGuest), hall.Dequeue());
                        sum = 0;
                        hallsGuest.Clear();

                    }

                }
            }
        }
    }
}
