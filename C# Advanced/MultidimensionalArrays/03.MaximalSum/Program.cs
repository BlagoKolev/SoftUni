using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = ReadFromConsole();
            var row = size[0];
            var col = size[1];

            var matrix = new int[row, col];

            if (matrix.GetLength(0) < 3 || matrix.GetLength(1) < 3)
            {
                return;
            }

            for (int rows = 0; rows < row; rows++)
            {
                var line = ReadFromConsole();

                for (int cols = 0; cols < col; cols++)
                {
                    matrix[rows, cols] = line[cols];
                }
            }

            var currentResult = 0;
            var maxResult = 0;
            var innerMatrix = new int[3, 3];

            for (int inRow = 0; inRow < row; inRow++)
            {
                if (inRow == row - 2)
                {
                    break;
                }

                for (int inCol = 0; inCol < col; inCol++)
                {
                    currentResult = 0;
                    if (inCol == col - 2)
                    {
                        break;
                    }
                    currentResult += matrix[inRow, inCol]
                        + matrix[inRow, inCol + 1]
                        + matrix[inRow, inCol + 2]
                        + matrix[inRow + 1, inCol]
                        + matrix[inRow + 1, inCol + 1]
                        + matrix[inRow + 1, inCol + 2]
                        + matrix[inRow + 2, inCol]
                        + matrix[inRow + 2, inCol + 1]
                        + matrix[inRow + 2, inCol + 2];
                    if (currentResult > maxResult)
                    {
                        maxResult = currentResult;
                        innerMatrix[0, 0] = matrix[inRow, inCol];
                        innerMatrix[0, 1] = matrix[inRow, inCol + 1];
                        innerMatrix[0, 2] = matrix[inRow, inCol + 2];
                        innerMatrix[1, 0] = matrix[inRow + 1, inCol];
                        innerMatrix[1, 1] = matrix[inRow + 1, inCol + 1];
                        innerMatrix[1, 2] = matrix[inRow + 1, inCol + 2];
                        innerMatrix[2, 0] = matrix[inRow + 2, inCol];
                        innerMatrix[2, 1] = matrix[inRow + 2, inCol + 1];
                        innerMatrix[2, 2] = matrix[inRow + 2, inCol + 2];

                    }
                }
            }
            if (maxResult == 0)
            {
                Console.WriteLine($"0 " + $"0 " + $"0");
                Console.WriteLine($"0 " + $"0 " + $"0");
                Console.WriteLine($"0 " + $"0 " + $"0");
                return;
            }
            Console.WriteLine("Sum = {0}", maxResult);
            for (int rows = 0; rows < 3; rows++)
            {
                for (int cols = 0; cols < 3; cols++)
                {
                    Console.Write("{0} ", innerMatrix[rows, cols]);
                }
                Console.WriteLine();
            }
        }
        public static int[] ReadFromConsole()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            return input;
        }
    }
}
