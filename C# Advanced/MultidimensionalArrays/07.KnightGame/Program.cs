using System;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var rows = size;
            var cols = size;

            var board = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    board[row, col] = line[col];
                }
            }

           
            var previousPossibleKills = 0;
            var rowToRemove = -1;
            var colToRemove = -1;
            var countOfRemovedFigure = 0;

            while (true)
            {
                var isPossibleToKill = false;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        var currentPossibleKills = 0;
                        var currentFigure = board[row, col];

                        if (currentFigure == 'K')
                        {
                            var figureRow = row;
                            var figureCol = col;

                            if (IsLeftAndUpMovePossible(figureRow, figureCol))
                            {
                                if (board[figureRow - 2, figureCol - 1] == 'K')
                                {
                                    currentPossibleKills++;
                                    isPossibleToKill = true;
                                }
                            }

                            if (IsLeftAndDownMovePossible(board, figureRow, figureCol))
                            {
                                if (board[figureRow + 2, figureCol - 1] == 'K')
                                {
                                    currentPossibleKills++;
                                    isPossibleToKill = true;

                                }
                            }

                            if (IsRifhtAndUpMovePossible(board, figureRow, figureCol))
                            {
                                if (board[figureRow - 2, figureCol + 1] == 'K')
                                {
                                    currentPossibleKills++;
                                    isPossibleToKill = true;

                                }
                            }

                            if (IsRightAndDownMovePossible(board, figureRow, figureCol))
                            {
                                if (board[figureRow + 2, figureCol + 1] == 'K')
                                {
                                    currentPossibleKills++;
                                    isPossibleToKill = true;
                                }
                            }

                            if (IsDownAndLeftMovePossible(board, figureRow, figureCol))
                            {
                                if (board[figureRow + 1, figureCol - 2] == 'K')
                                {
                                    currentPossibleKills++;
                                    isPossibleToKill = true;
                                }
                            }

                            if (IsDownAndRightMovePossible(board, figureRow, figureCol))
                            {
                                if (board[figureRow + 1, figureCol + 2] == 'K')
                                {
                                    currentPossibleKills++;
                                    isPossibleToKill = true;
                                }
                            }

                            if (IsUpAndLeftMovePossible(board, figureRow, figureCol))
                            {
                                if (board[figureRow - 1, figureCol - 2] == 'K')
                                {
                                    currentPossibleKills++;
                                    isPossibleToKill = true;
                                }
                            }

                            if (IsUpAndRightMovePossible(board, figureRow, figureCol))
                            {
                                if (board[figureRow - 1, figureCol + 2] == 'K')
                                {
                                    currentPossibleKills++;
                                    isPossibleToKill = true;
                                }
                            }

                            if (currentPossibleKills > previousPossibleKills)
                            {
                                previousPossibleKills = currentPossibleKills;
                                rowToRemove = figureRow;
                                colToRemove = figureCol;
                            }
                        }
                    }
                }
                if (isPossibleToKill == false)
                {
                    break;
                }
                board[rowToRemove, colToRemove] = '0';
                countOfRemovedFigure++;
                previousPossibleKills = 0;
            }
            Console.WriteLine(countOfRemovedFigure);
        }
        public static bool IsLeftAndUpMovePossible(int row, int col)
        {
            var isPossible = false;
            if (col - 1 >= 0 && row - 2 >= 0)
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool IsLeftAndDownMovePossible(char[,] matrix, int row, int col)
        {
            var isPossible = false;

            if (col - 1 >= 0 && row + 2 < matrix.GetLength(0))
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool IsRifhtAndUpMovePossible(char[,] matrix, int row, int col)
        {
            var isPossible = false;
            if (col + 1 < matrix.GetLength(1) && row - 2 >= 0)
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool IsRightAndDownMovePossible(char[,] matrix, int row, int col)
        {
            var isPossible = false;
            if (col + 1 < matrix.GetLength(1) && row + 2 < matrix.GetLength(0))
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool IsDownAndLeftMovePossible(char[,] matrix, int row, int col)
        {
            var isPossible = false;
            if (row + 1 < matrix.GetLength(0) && col - 2 >= 0)
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool IsDownAndRightMovePossible(char[,] matrix, int row, int col)
        {
            var isPossible = false;
            if (row + 1 < matrix.GetLength(0) && col + 2 < matrix.GetLength(1))
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool IsUpAndLeftMovePossible(char[,] matrix, int row, int col)
        {
            var isPossible = false;
            if (row - 1 >= 0 && col - 2 >= 0)
            {
                isPossible = true;
            }
            return isPossible;
        }

        public static bool IsUpAndRightMovePossible(char[,] matrix, int row, int col)
        {
            var isPossible = false;
            if (row - 1 >= 0 && col + 2 < matrix.GetLength(1))
            {
                isPossible = true;
            }
            return isPossible;
        }

    }
}
