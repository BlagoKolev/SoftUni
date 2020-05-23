using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultidimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new int[n, n];

            for (int rows = 0; rows < n; rows++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = line[cols];
                }
            }

            var primaryDiagonal = 0;
            for (int i = 0; i < n; i++)
            {
                primaryDiagonal += matrix[i, i];
            }

            var secondaryDiagonal = 0;

            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = n - 1; cols >= 0; cols--)
                {
                    secondaryDiagonal += matrix[rows, cols];
                    rows++;
                }
                break;
            }
            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}
