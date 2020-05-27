using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var rows = size;
            var cols = size;

            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            var coordinates = Console.ReadLine().Split();
            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] currentCoordinate = coordinates[i].Split(new char[] { ',' }
                    , StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var x = currentCoordinate[0];
                var y = currentCoordinate[1];

                var currentCellValue = matrix[x, y];
                if (currentCellValue <= 0)
                {
                    continue;
                }

                if (IsUpExplodePossible(matrix, x, y) && (matrix[x - 1, y]) > 0)
                {
                    matrix[x - 1, y] -= currentCellValue;
                }

                if (IsDownExplodePossible(matrix, x, y) && matrix[x + 1, y] > 0)
                {
                    matrix[x + 1, y] -= currentCellValue;
                }

                if (IsLeftExplodePossible(matrix, x, y) && matrix[x, y - 1] > 0)
                {
                    matrix[x, y - 1] -= currentCellValue;
                }

                if (IsRightExplodePossible(matrix, x, y) && matrix[x, y + 1] > 0)
                {
                    matrix[x, y + 1] -= currentCellValue;
                }

                if (IsLeftUpperExplodePossible(IsLeftExplodePossible(matrix, x, y), IsUpExplodePossible(matrix, x, y)) && matrix[x - 1, y - 1] > 0)
                {
                    matrix[x - 1, y - 1] -= currentCellValue;
                }

                if (IsLeftDownExplodePossible(IsLeftExplodePossible(matrix, x, y)
                    , IsDownExplodePossible(matrix, x, y))
                    && matrix[x + 1, y - 1] > 0)
                {
                    matrix[x + 1, y - 1] -= currentCellValue;
                }

                if (IsDownRightExplodePossible(IsDownExplodePossible(matrix, x, y)
                    , IsRightExplodePossible(matrix, x, y))
                    && matrix[x + 1, y + 1] > 0)
                {
                    matrix[x + 1, y + 1] -= currentCellValue;
                }

                if (IsRightUpperExplodePossible(IsRightExplodePossible(matrix, x, y), IsUpExplodePossible(matrix, x, y)) && matrix[x - 1, y + 1] > 0)
                {
                    matrix[x - 1, y + 1] -= currentCellValue;
                }

                matrix[x, y] = 0;
            } //For Loop Ends

            var aliveCells = 0;
            var sumOfAliveCells = 0;

            foreach (var cell in matrix)
            {
                if (cell > 0)
                {
                    aliveCells++;
                    sumOfAliveCells += cell;
                }
            }

            Console.WriteLine("Alive cells: {0}", aliveCells);
            Console.WriteLine("Sum: {0}", sumOfAliveCells);
            PrintMatrix(matrix);



        }
        public static bool IsUpExplodePossible(int[,] matrix, int row, int col)
        {
            var isPossible = false;
            if (row - 1 >= 0)
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool IsDownExplodePossible(int[,] matrix, int row, int col)
        {
            var isPossible = false;
            if (row + 1 < matrix.GetLength(0))
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool IsLeftExplodePossible(int[,] matrix, int row, int col)
        {
            var isPossible = false;
            if (col - 1 >= 0)
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool IsRightExplodePossible(int[,] matrix, int row, int col)
        {
            var isPossible = false;
            if (col + 1 < matrix.GetLength(1))
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool IsLeftUpperExplodePossible(bool IsLeftExplodePossible, bool IsUpExplodePossible)
        {
            var isPossible = false;
            if (IsLeftExplodePossible && IsUpExplodePossible)
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool IsRightUpperExplodePossible(bool IsRightExplodePossible, bool IsUpExplodePossible)
        {
            bool isPossible = false;
            if (IsRightExplodePossible && IsUpExplodePossible)
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool IsLeftDownExplodePossible(bool IsLeftExplodePossible, bool IsDownExplodePossible)
        {
            var isPossible = false;
            if (IsLeftExplodePossible && IsDownExplodePossible)
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool IsDownRightExplodePossible(bool IsRightExplodePossible, bool IsDownExplodePossible)
        {
            var isPossible = false;
            if (IsDownExplodePossible && IsRightExplodePossible)
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0} ", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
