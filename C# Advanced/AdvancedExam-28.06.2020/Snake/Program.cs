using System;
using System.Collections.Generic;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            var matrix = new char[size, size];

            var snakeRow = 0;
            var snakeCol = 0;
            var burrow1Row = 0;
            var burrow1Col = 0;
            var burrow2Row = 0;
            var burrow2Col = 0;
            var burrow1Marked = false;
            var food = 0;
            var outOfTerritory = false;

            for (int row = 0; row < size; row++)
            {
                var line = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = line[col];

                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                        matrix[snakeRow, snakeCol] = '.';
                    }

                    if (matrix[row, col] == 'B')
                    {
                        if (burrow1Marked == false)
                        {
                            burrow1Row = row;
                            burrow1Col = col;
                            burrow1Marked = true;
                        }
                        else
                        {
                            burrow2Row = row;
                            burrow2Col = col;
                        }

                    }
                }
            }
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "left")
                {
                    snakeCol--;
                    if (snakeCol < 0)
                    {
                        snakeCol = 0;
                        outOfTerritory = true;
                        break;
                    }
                    if (matrix[snakeRow, snakeCol] == '*')
                    {
                        food++;
                        matrix[snakeRow, snakeCol] = '.';
                    }
                    else if (snakeRow == burrow1Row && snakeCol == burrow1Col)
                    {
                        matrix[burrow1Row, burrow1Col] = '.';
                        snakeRow = burrow2Row;
                        snakeCol = burrow2Col;
                        matrix[snakeRow, snakeCol] = '.';
                    }
                    else if (snakeRow == burrow2Row && snakeCol == burrow2Col)
                    {
                        matrix[burrow2Row, burrow2Col] = '.';
                        snakeRow = burrow1Row;
                        snakeCol = burrow1Col;
                        matrix[snakeRow, snakeCol] = '.';
                    }
                    matrix[snakeRow, snakeCol] = '.';
                    if (food >= 10)
                    {
                        break;
                    }
                }
               else if (command == "right")
                {
                    snakeCol++;
                    if (snakeCol == matrix.GetLength(1))
                    {
                        snakeCol=matrix.GetLength(1)-1;
                        outOfTerritory = true;
                        break;
                    }
                    if (matrix[snakeRow, snakeCol] == '*')
                    {
                        food++;
                        matrix[snakeRow, snakeCol] = '.';
                    }
                    else if (snakeRow == burrow1Row && snakeCol == burrow1Col)
                    {
                        matrix[burrow1Row, burrow1Col] = '.';
                        snakeRow = burrow2Row;
                        snakeCol = burrow2Col;
                        matrix[snakeRow, snakeCol] = '.';
                    }
                    else if (snakeRow == burrow2Row && snakeCol == burrow2Col)
                    {
                        matrix[burrow2Row, burrow2Col] = '.';
                        snakeRow = burrow1Row;
                        snakeCol = burrow1Col;
                        matrix[snakeRow, snakeCol] = '.';
                    }
                    matrix[snakeRow, snakeCol] = '.';
                    if (food >= 10)
                    {
                        break;
                    }
                }
               else if (command == "up")
                {
                    snakeRow--;
                    if (snakeRow < 0)
                    {
                        snakeRow = 0;
                        outOfTerritory = true;
                        break;
                    }
                    if (matrix[snakeRow, snakeCol] == '*')
                    {
                        food++;
                        matrix[snakeRow, snakeCol] = '.';
                    }
                    else if (snakeRow == burrow1Row && snakeCol == burrow1Col)
                    {
                        matrix[burrow1Row, burrow1Col] = '.';
                        snakeRow = burrow2Row;
                        snakeCol = burrow2Col;
                        matrix[snakeRow, snakeCol] = '.';
                    }
                    else if (snakeRow == burrow2Row && snakeCol == burrow2Col)
                    {
                        matrix[burrow2Row, burrow2Col] = '.';
                        snakeRow = burrow1Row;
                        snakeCol = burrow1Col;
                        matrix[snakeRow, snakeCol] = '.';
                    }
                    matrix[snakeRow, snakeCol] = '.';
                    if (food >= 10)
                    {
                        break;
                    }
                }
                else if (command == "down")
                {
                    snakeRow++;
                    if (snakeRow == matrix.GetLength(0))
                    {
                        snakeRow = matrix.GetLength(0) - 1;
                        outOfTerritory = true;
                        break;
                    }
                    if (matrix[snakeRow, snakeCol] == '*')
                    {
                        food++;
                        matrix[snakeRow, snakeCol] = '.';
                    }
                    else if (snakeRow == burrow1Row && snakeCol == burrow1Col)
                    {
                        matrix[burrow1Row, burrow1Col] = '.';
                        snakeRow = burrow2Row;
                        snakeCol = burrow2Col;
                        matrix[snakeRow, snakeCol] = '.';
                    }
                    else if (snakeRow == burrow2Row && snakeCol == burrow2Col)
                    {
                        matrix[burrow2Row, burrow2Col] = '.';
                        snakeRow = burrow1Row;
                        snakeCol = burrow1Col;
                        matrix[snakeRow, snakeCol] = '.';
                    }
                    matrix[snakeRow, snakeCol] = '.';
                    if (food >= 10)
                    {
                        break;
                    }
                }
            }

            if (outOfTerritory)
            {
                matrix[snakeRow, snakeCol] = '.';
                Console.WriteLine("Game over!");
            }
            else
            {
                matrix[snakeRow, snakeCol] = 'S';
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {food}");
            PrintMatrix(matrix);
        }
        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}

