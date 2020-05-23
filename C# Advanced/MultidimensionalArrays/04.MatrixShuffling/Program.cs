using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = ReadInput();
            var rows = size[0];
            var cols = size[1];

            var matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            while (true)
            {
                var command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "END")
                {
                    break;
                }

                if (IsInputValid(command))
                {
                    var row1 = int.Parse(command[1]);
                    var col1 = int.Parse(command[2]);
                    var row2 = int.Parse(command[3]);
                    var col2 = int.Parse(command[4]);

                    if ((row1 > -1 && row1 < matrix.GetLength(0))
                        && (row2 > -1 && row2 < matrix.GetLength(0))
                        && (col1 > -1 && col1 < matrix.GetLength(1)
                        && (col2 > -1 && col2 < matrix.GetLength(1))))
                    {
                        var firstValue = matrix[row1, col1];
                        var secondValue = matrix[row2, col2];
                        var helperValue = string.Empty;

                        helperValue = firstValue;
                        matrix[row1, col1] = secondValue;
                        matrix[row2, col2] = helperValue;

                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }


                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }


        }
        public static int[] ReadInput()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            return input;
        }

        public static bool IsInputValid(string[] command)
        {
            var isValid = true;

            if (command[0] != "swap" || command.Length != 5)
            {
                isValid = false;
            }
            return isValid;
        }

        public static void PrintMatrix(string[,] matrix)
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
