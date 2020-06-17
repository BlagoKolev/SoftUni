using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            var startText = Console.ReadLine();
            var size = int.Parse(Console.ReadLine());
            var rows = size;
            var cols = size;
            var playerRow = 0;
            var playerCol = 0;

            var matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                if (command == "left")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerCol--;
                    if (playerCol < 0)
                    {
                        playerCol = 0;
                        if (startText.Length > 1)
                        {
                            startText = startText.Remove(startText.Length - 1, 1);
                        }
                        matrix[playerRow, playerCol] = 'P';
                    }
                    else
                    {

                        if (matrix[playerRow, playerCol] != '-')
                        {
                            var symbol = matrix[playerRow, playerCol];
                            startText = startText + symbol;
                            matrix[playerRow, playerCol] = 'P';
                        }
                    }
                }

                else if (command == "right")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerCol++;
                    if (playerCol == matrix.GetLength(1))
                    {
                        playerCol = matrix.GetLength(1) - 1;
                        if (startText.Length > 1)
                        {
                            startText = startText.Remove(startText.Length - 1, 1);
                        }
                        matrix[playerRow, playerCol] = 'P';
                    }
                    else
                    {
                        if (matrix[playerRow, playerCol] != '-')
                        {
                            var symbol = matrix[playerRow, playerCol];
                            startText = startText + symbol;
                            matrix[playerRow, playerCol] = 'P';
                        }
                    }
                }

                else if (command == "up")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerRow--;
                    if (playerRow < 0)
                    {
                        playerRow = 0;
                        if (startText.Length > 1)
                        {
                            startText = startText.Remove(startText.Length - 1, 1);
                        }
                        matrix[playerRow, playerCol] = 'P';
                    }
                    else
                    {
                        if (matrix[playerRow, playerCol] != '-')
                        {
                            var symbol = matrix[playerRow, playerCol];
                            startText = startText + symbol;
                            matrix[playerRow, playerCol] = 'P';
                        }
                    }
                }

                else if (command == "down")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerRow++;
                    if (playerRow == matrix.GetLength(0))
                    {
                        playerRow = matrix.GetLength(0) - 1;
                        if (startText.Length > 1)
                        {
                            startText = startText.Remove(startText.Length - 1, 1);
                        }
                        matrix[playerRow, playerCol] = 'P';
                    }
                    else
                    {
                        if (matrix[playerRow, playerCol] != '-')
                        {
                            var symbol = matrix[playerRow, playerCol];
                            startText = startText + symbol;
                            matrix[playerRow, playerCol] = 'P';
                        }
                    }
                }
            }
            Console.WriteLine(startText);
            PrintMatrix(matrix);
        }
        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
