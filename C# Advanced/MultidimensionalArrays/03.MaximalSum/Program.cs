using System;
using System.Linq;


namespace _03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = ReadFromConsole();
            var rows = size[0];
            var cols = size[1];

            var matrix = new int[rows, cols];


            for (int row = 0; row < rows; row++)
            {
                var line = ReadFromConsole();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }


            var maxResult = int.MinValue;
            var maxRow = 0;
            var maxCol = 0;

            for (int row = 0; row < rows - 2; row++)
            {

                for (int col = 0; col < cols - 2; col++)
                {
                    var currentResult = 0;

                    currentResult += matrix[row, col]
                        + matrix[row, col + 1]
                        + matrix[row, col + 2]
                        + matrix[row + 1, col]
                        + matrix[row + 1, col + 1]
                        + matrix[row + 1, col + 2]
                        + matrix[row + 2, col]
                        + matrix[row + 2, col + 1]
                        + matrix[row + 2, col + 2];
                    if (currentResult > maxResult)
                    {
                        maxResult = currentResult;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine("Sum = {0}", maxResult);
            for (int i = maxRow; i < maxRow + 3; i++)
            {
                for (int j = maxCol; j < maxCol + 3; j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static int[] ReadFromConsole()
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            return input;
        }
    }
}
