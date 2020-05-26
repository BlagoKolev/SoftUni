using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var rows = size;
            var cols = size;
            var commands = Console.ReadLine().Split();

            var matrix = new char[rows, cols];

            var coalsInMatrix = 0;
            var minerRow = 0;
            var minerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];

                    if (matrix[row, col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                    if (matrix[row, col] == 'c')
                    {
                        coalsInMatrix++;
                    }
                }
            }

            for (int i = 0; i < commands.Length; i++)
            {
                var currentCommand = commands[i];

                if (currentCommand == "left")
                {

                    if (IsMoveLeftPossible(matrix, minerRow, minerCol))
                    {
                        minerCol--;
                    }
                }

                else if (currentCommand == "right")
                {
                    if (IsMoveRightPossible(matrix, minerRow, minerCol))
                    {
                        minerCol++;
                    }
                }

                else if (currentCommand == "up")
                {

                    if (IsMoveUpPossible(matrix, minerRow, minerCol))
                    {
                        minerRow--;
                    }
                }

                else if (currentCommand == "down")
                {
                    if (IsMoveDownPossible(matrix, minerRow, minerCol))
                    {
                        minerRow++;
                    }
                }

                if (CheckForCoal(matrix, minerRow, minerCol))
                {
                    coalsInMatrix--;
                    matrix[minerRow, minerCol] = '*';
                }

                if (AreCoalsAreZero(matrix, minerRow, minerCol, coalsInMatrix))
                {
                    Console.WriteLine("You collected all coals! ({0}, {1})", minerRow, minerCol);
                    return;
                }

                if (CheckForEndGame(matrix, minerRow, minerCol))
                {
                    Console.WriteLine("Game over! ({0}, {1})", minerRow, minerCol);
                    return;
                }
            }

            Console.WriteLine("{0} coals left. ({1}, {2})", coalsInMatrix, minerRow, minerCol);

        }
        public static bool IsMoveLeftPossible(char[,] matrix, int row, int col)
        {
            var isPossible = false;
            if (col - 1 >= 0)
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool IsMoveRightPossible(char[,] matrix, int row, int col)
        {
            var isPossible = false;
            if (col + 1 < matrix.GetLength(1))
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool IsMoveUpPossible(char[,] matrix, int row, int col)
        {
            var isPossible = false;

            if (row - 1 >= 0)
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool IsMoveDownPossible(char[,] matrix, int row, int col)
        {
            var isPossible = false;

            if (row + 1 < matrix.GetLength(0))
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool CheckForCoal(char[,] matrix, int minerRow, int minerCol)
        {
            var isCoal = false;
            if (matrix[minerRow, minerCol] == 'c')
            {
                isCoal = true;
            }
            return isCoal;
        }

        public static bool AreCoalsAreZero(char[,] matrix, int minerRow, int minerCol, int coalsInMatrix)
        {
            var areZero = false;
            if (coalsInMatrix == 0)
            {
                areZero = true;
            }
            return areZero;
        }


        public static bool CheckForEndGame(char[,] matrix, int minerRow, int minerCol)
        {
            var isGameEdns = false;
            if (matrix[minerRow, minerCol] == 'e')
            {
                isGameEdns = true;
            }
            return isGameEdns;
        }


    }
}
