using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = Console.ReadLine().Split(new string[] { ", " }
                , StringSplitOptions
                .RemoveEmptyEntries)
                .ToArray();

            var songQueue = new Queue<string>(songs);

            while (songQueue.Any())
            {
                var command = Console.ReadLine();
                if (command.StartsWith("Play"))
                {
                    songQueue.Dequeue();

                }

                else if (command.StartsWith("Add"))
                {
                    var songToAdd = command.Substring(4);
                    if (!songQueue.Contains(songToAdd))
                    {
                        songQueue.Enqueue(songToAdd);
                    }
                    else
                    {
                        Console.WriteLine("{0} is already contained!", songToAdd);
                    }
                }

                else if (command.StartsWith("Show"))
                {

                    Console.WriteLine(string.Join(", ", songQueue));
                }

            }
            Console.WriteLine("No more songs!");
        }
    }
}