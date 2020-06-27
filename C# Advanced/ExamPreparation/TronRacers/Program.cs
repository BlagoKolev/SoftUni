using System;

namespace TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            var matrix = new char[size, size];
            var firstPlayerRow = 0;
            var firstPlayerCol = 0;
            var secondPlayerRow = 0;
            var secondPlayerCol = 0;

            for (int row = 0; row < size; row++)
            {
                var line = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = line[col];
                    if (matrix[row, col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }
                    else if (matrix[row, col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }
                }
            }
            var allPlayersAreAlive = true;

            while (true)
            {
                var command = Console.ReadLine().Split();
                if (command[0] == "left")
                {
                    allPlayersAreAlive = MoveLeft(matrix,ref firstPlayerRow, ref firstPlayerCol, allPlayersAreAlive);
                }

                else if (command[0] == "right")
                {
                    allPlayersAreAlive = MoveRight(matrix, ref firstPlayerRow, ref firstPlayerCol, allPlayersAreAlive);
                }

                else if (command[0] == "up")
                {
                    allPlayersAreAlive = MoveUp(matrix, ref firstPlayerRow, ref firstPlayerCol, allPlayersAreAlive);
                }

                else if (command[0] == "down")
                {
                    allPlayersAreAlive = MoveDown(matrix, ref firstPlayerRow, ref firstPlayerCol, allPlayersAreAlive);
                }

                if (allPlayersAreAlive == false)
                {
                    matrix[firstPlayerRow, firstPlayerCol] = 'x';
                    break;
                }

                if (command[1] == "left")
                {
                    allPlayersAreAlive = MoveLeft(matrix, ref secondPlayerRow, ref secondPlayerCol, allPlayersAreAlive);
                }

                else if (command[1] == "right")
                {
                    allPlayersAreAlive = MoveRight(matrix, ref secondPlayerRow, ref secondPlayerCol, allPlayersAreAlive);
                }

                else if (command[1] == "up")
                {
                    allPlayersAreAlive = MoveUp(matrix, ref secondPlayerRow, ref secondPlayerCol, allPlayersAreAlive);
                }

                else if (command[1] == "down")
                {
                    allPlayersAreAlive = MoveDown(matrix, ref secondPlayerRow, ref secondPlayerCol, allPlayersAreAlive);
                }
                if (allPlayersAreAlive == false)
                {
                    matrix[secondPlayerRow, secondPlayerCol] = 'x';
                    break;
                }
            }

            PrintMatrix(matrix);

        }
        public static bool MoveLeft(char[,] matrix,ref int playerRow,ref int playerCol, bool allPlayersAreAlive)
        {
            var playerSymbol = matrix[playerRow, playerCol];

            playerCol--;
            if (playerCol < 0)
            {
                playerCol = matrix.GetLength(1) - 1;
            }
            if (matrix[playerRow, playerCol] != '*')
            {
                allPlayersAreAlive = false;
            }
            matrix[playerRow, playerCol] = playerSymbol;
            return allPlayersAreAlive;
        }
        public static bool MoveRight(char[,] matrix,ref int playerRow,ref int playerCol, bool allPlayersAreAlive)
        {
            var playerSymbol = matrix[playerRow, playerCol];
            playerCol++;
            if (playerCol == matrix.GetLength(1))
            {
                playerCol = 0;
            }
            if (matrix[playerRow, playerCol] != '*')
            {
                allPlayersAreAlive = false;
            }
            matrix[playerRow, playerCol] = playerSymbol;
            return allPlayersAreAlive;
        }
        public static bool MoveUp(char[,] matrix,ref int playerRow,ref int playerCol, bool allPlayersAreAlive)
        {
            var playerSymbol = matrix[playerRow, playerCol];
            playerRow--;
            if (playerRow < 0)
            {
                playerCol = matrix.GetLength(0) - 1;
            }
            if (matrix[playerRow, playerCol] != '*')
            {
                allPlayersAreAlive = false;
            }
            matrix[playerRow, playerCol] = playerSymbol;
            return allPlayersAreAlive;
        }
        public static bool MoveDown(char[,] matrix,ref int playerRow, ref int playerCol, bool allPlayersAreAlive)
        {
            var playerSymbol = matrix[playerRow, playerCol];
            playerRow++;
            if (playerRow == matrix.GetLength(0))
            {
                playerCol = 0;
            }
            if (matrix[playerRow, playerCol] != '*')
            {
                allPlayersAreAlive = false;
            }
            matrix[playerRow, playerCol] = playerSymbol;
            return allPlayersAreAlive;
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
