using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split();
            var rows = int.Parse(size[0]);
            var cols = int.Parse(size[1]);
            var matrix = new char[rows, cols];
            var playerRow = 0;
            var playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (currentRow[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                        matrix[row, col] = '.';
                    }
                }
            }

            var commands = Console.ReadLine();
            var playerIsDead = false;
            var playerWin = false;

            for (int i = 0; i < commands.Length; i++)
            {
                var curentCommand = commands[i];
                if (curentCommand == 'L')
                {
                    playerCol--;
                    if (playerCol < 0)
                    {
                        playerWin = true;
                        playerCol = 0;
                    }

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerIsDead = true;
                    }
                    SpreadBunnies(rows, cols, matrix);

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerIsDead = true;
                    }
                }

                else if (curentCommand == 'R')
                {
                    playerCol++;
                    if (playerCol >= matrix.GetLength(1))
                    {
                        playerWin = true;
                        playerCol = matrix.GetLength(1) - 1;
                    }

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerIsDead = true;
                    }

                    SpreadBunnies(rows, cols, matrix);

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerIsDead = true;
                    }
                }

                else if (curentCommand == 'U')
                {
                    playerRow--;
                    if (playerRow < 0)
                    {
                        playerWin = true;
                        playerRow = 0;
                    }

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerIsDead = true;
                    }
                    SpreadBunnies(rows, cols, matrix);

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerIsDead = true;
                    }
                }

                else if (curentCommand == 'D')
                {
                    playerRow++;
                    if (playerRow >= matrix.GetLength(0))
                    {
                        playerWin = true;
                        playerRow = matrix.GetLength(0) - 1;
                    }

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerIsDead = true;
                    }

                    SpreadBunnies(rows, cols, matrix);

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerIsDead = true;
                    }
                }

                if (playerWin == true)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine("won: {0} {1}", playerRow, playerCol);
                    break;
                }
                else if (playerIsDead == true)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine("dead: {0} {1}", playerRow, playerCol);
                    break;
                }
            }   //END OF FOR LOOP




        }//start of methods
        public static bool MoveLeft(int row, int col, char[,] matrix)
        {
            bool isPossible = false;
            if (col - 1 >= 0)
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool MoveRight(int row, int col, char[,] matrix)
        {
            bool isPossible = false;
            if (col + 1 < matrix.GetLength(1))
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool MoveUp(int row, int col, char[,] matrix)
        {
            bool isPossible = false;
            if (row - 1 >= 0)
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool MoveDown(int row, int col, char[,] matrix)
        {
            bool isPossible = false;
            if (row + 1 < matrix.GetLength(0))
            {
                isPossible = true;
            }
            return isPossible;
        }
        //SPREAD BUNNIES !!!
        public static char[,] SpreadBunnies(int rows, int cols, char[,] matrix)
        {
            var refMatrix = new char[matrix.GetLength(0), matrix.GetLength(1)];
            Array.Copy(matrix, refMatrix, matrix.Length);
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {

                    if (matrix[row, col] == 'B')
                    {

                        if (MoveLeft(row, col, matrix))
                        {
                            refMatrix[row, col - 1] = 'B';
                        }
                        if (MoveRight(row, col, matrix))
                        {
                            refMatrix[row, col + 1] = 'B';
                        }
                        if (MoveUp(row, col, matrix))
                        {
                            refMatrix[row - 1, col] = 'B';
                        }
                        if (MoveDown(row, col, matrix))
                        {
                            refMatrix[row + 1, col] = 'B';
                        }
                    }

                }
            }
            Array.Copy(refMatrix, matrix, refMatrix.Length);
            return matrix;
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
