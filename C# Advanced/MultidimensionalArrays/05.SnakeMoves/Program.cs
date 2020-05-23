using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = size[0];
            var cols = size[1];
            var snake = Console.ReadLine();
            var snakeIndex = 0;

            var matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (snakeIndex == snake.Length)
                        {
                            snakeIndex = 0;
                        }
                        matrix[row, col] = snake[snakeIndex];
                        snakeIndex++;
                        if (col == matrix.GetLength(1))
                        {
                            break;
                        }

                    }
                }

                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (snakeIndex == snake.Length)
                        {
                            snakeIndex = 0;
                        }
                        matrix[row, col] = snake[snakeIndex];
                        snakeIndex++;
                        if (col == matrix.GetLength(1))
                        {
                            break;
                        }
                    }
                }
            }
            PrinMatrix(matrix);
        }
        public static void PrinMatrix(char[,] matrix)
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
