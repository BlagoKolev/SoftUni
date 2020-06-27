using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var capacity = int.Parse(Console.ReadLine());
            var input = new Stack<string>(Console.ReadLine().Split());

            var hallsQueue = new Queue<string>();
            var reservations = new Dictionary<string, List<int>>();

            var peopleInHall = 0;
            var hall = string.Empty;

            while (input.Any())
            {
                var currentObject = input.Peek();
                var digit = 0;
                var isDigit = int.TryParse(currentObject, out digit);

                if (!isDigit)
                {
                    input.Pop();
                    hallsQueue.Enqueue(currentObject);
                    if (!reservations.Any())
                    {
                        hall = hallsQueue.Dequeue();
                        reservations[hall] = new List<int>();
                    }
                }
                else
                {
                    if (!reservations.Any())
                    {
                        input.Pop();
                        continue;
                    }
                    if (digit + peopleInHall <= capacity)
                    {
                        peopleInHall += digit;
                        reservations[hall].Add(digit);
                        input.Pop();
                    }
                    else
                    {
                        foreach (var reservation in reservations)
                        {
                            Console.Write($"{reservation.Key} -> ");
                            Console.WriteLine(string.Join(", ", reservation.Value));
                        }
                        peopleInHall = 0;
                        reservations.Clear();
                    }
                }
                if (!reservations.Any())
                {
                    if (hallsQueue.Any())
                    {
                        hall = hallsQueue.Dequeue();
                        reservations[hall] = new List<int>();
                    }
                    
                }



            }
        }

    }

}
