using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamPreparationAdvanced
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var rows = size;
            var cols = size;
            var n = int.Parse(Console.ReadLine());
            var matrix = new char[rows, cols];
            var playerRow = 0;
            var playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                        matrix[row, col] = '-';
                    }
                }
            }

            var IsWinner = false;

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine();


                switch (command)
                {
                    case "left":
                        playerCol--;

                        if (playerCol < 0)
                        {
                            playerCol = matrix.GetLength(1) - 1;
                        }
                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            IsWinner = true;
                        }
                        else if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerCol--;
                            if (playerCol < 0)
                            {
                                playerCol = matrix.GetLength(1) - 1;
                            }
                            if (matrix[playerRow, playerCol] == 'F')
                            {
                                IsWinner = true;
                            }
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerCol++;
                        }
                        break;

                    case "right":
                        playerCol++;
                        if (playerCol == matrix.GetLength(1))
                        {
                            playerCol = 0;
                        }
                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            IsWinner = true;
                        }
                        else if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerCol++;
                            if (playerCol == matrix.GetLength(1))
                            {
                                playerCol = 0;
                            }
                            if (matrix[playerRow, playerCol] == 'F')
                            {
                                IsWinner = true;
                            }
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerCol--;
                        }
                        break;

                    case "up":
                        playerRow--;

                        if (playerRow < 0)
                        {
                            playerRow = matrix.GetLength(0) - 1;
                        }
                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            IsWinner = true;
                        }
                        else if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerRow--;
                            if (playerRow < 0)
                            {
                                playerRow = matrix.GetLength(0) - 1;
                            }
                            if (matrix[playerRow, playerCol] == 'F')
                            {
                                IsWinner = true;
                            }
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerRow++;
                        }
                        break;

                    case "down":
                        playerRow++;

                        if (playerRow == matrix.GetLength(0))
                        {
                            playerRow = 0;
                        }
                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            IsWinner = true;
                        }
                        else if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerRow++;
                            if (playerRow == matrix.GetLength(0))
                            {
                                playerRow = 0;
                            }
                            if (matrix[playerRow, playerCol] == 'F')
                            {
                                IsWinner = true;
                            }
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerRow++;
                        }
                        break;
                }
                if (IsWinner)
                {
                    Console.WriteLine("Player won!");
                    break;
                }
            }

            if (IsWinner)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (row == playerRow && col == playerCol)
                        {
                            matrix[row, col] = 'f';
                        }
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Player lost!");
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (row == playerRow && col == playerCol)
                        {
                            matrix[row, col] = 'f';
                        }
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }
            }



        }

    }
}