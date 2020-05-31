using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                var command = Console.ReadLine();

                Action<int[]> print = array =>
                {
                    Console.WriteLine(string.Join(" ", array));
                };

                if (command == "end")
                {
                    break;
                }

                if (command == "print")
                {
                    print(numbers);
                }
                else
                {
                    Func<int[], int[]> transform = TransformArray(command);
                    numbers = transform(numbers);
                }    
            }
        }
        static Func<int[], int[]> TransformArray(string command)
        {
            Func<int[], int[]> transform = null;

            if (command == "add")
            {
                transform = new Func<int[], int[]>((array) =>
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i]++;
                    }
                    return array;
                });
            }

            else if (command == "multiply")
            {
                transform = new Func<int[], int[]>((array) =>
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] *= 2;
                    }
                    return array;
                });
            }

            else if (command == "subtract")
            {
                transform = new Func<int[], int[]>((array) =>
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i]--;
                    }
                    return array;
                });
            }
            return transform;
            }
        }
    }



