using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.CatapultAtack
{
    class Program
    {
        static void Main(string[] args)
        {
            var trojanPileCount = int.Parse(Console.ReadLine());
            var spartanWalls = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var wallsQueue = new Queue<int>(spartanWalls);
            Stack<int> rocksStack = null;

            for (int i = 1; i <= trojanPileCount; i++)
            {
                if (!wallsQueue.Any())
                {
                    break;
                }
                var rocks = Console.ReadLine().Split().Select(int.Parse).ToArray();
                rocksStack = new Stack<int>(rocks);

                if (i % 3 == 0)
                {
                    var addWall = int.Parse(Console.ReadLine());
                    wallsQueue.Enqueue(addWall);
                }

                while (wallsQueue.Any() && rocksStack.Any())
                {
                    var wall = wallsQueue.Dequeue();
                    var rock = rocksStack.Pop();

                    if (wall == rock)
                    {
                        continue;
                    }
                    else if (wall > rock)
                    {
                        wall -= rock;
                        wallsQueue.Enqueue(wall);
                        for (int j = 0; j < wallsQueue.Count - 1; j++)
                        {
                            wallsQueue.Enqueue(wallsQueue.Dequeue());
                        }

                    }
                    else if (rock > wall)
                    {
                        rock -= wall;
                        rocksStack.Push(rock);

                    }

                }
            }

            if (rocksStack.Any())
            {
                Console.WriteLine("Rocks left: {0}", string.Join(", ", rocksStack));
            }
            if (wallsQueue.Any())
            {
                Console.WriteLine("Walls left: {0}", string.Join(", ", wallsQueue));
            }

        }
    }
}
