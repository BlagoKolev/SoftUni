using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var rows = size;
            var cols = size;
            var matrix = new char[rows, cols];
            var player1Row = 0;
            var player1Col = 0;
            var player2Row = 0;
            var player2Col = 0;
            const char player1Mark = 'f';
            const char player2Mark = 's';
            var IsDead = false;
            const char dead = 'x';

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                    if (matrix[row, col] == 'f')
                    {
                        player1Row = row;
                        player1Col = col;
                    }
                    if (matrix[row, col] == 's')
                    {
                        player2Row = row;
                        player2Col = col;
                    }
                }
            }

            while (true)
            {
                var command = Console.ReadLine().Split();
                var firstCommand = command[0];
                var secondCommand = command[1];

                if (firstCommand == "left")
                {
                    player1Col--;
                    if (player1Col < 0)
                    {
                        player1Col = matrix.GetLength(1) - 1;
                    }
                    if (matrix[player1Row, player1Col] == player2Mark)
                    {
                        matrix[player1Row, player1Col] = dead;
                        IsDead = true;
                    }
                    else
                    {
                        matrix[player1Row, player1Col] = player1Mark;
                    }
                }
                else if (firstCommand == "right")
                {
                    player1Col++;
                    if (player1Col == matrix.GetLength(1))
                    {
                        player1Col = 0;
                    }
                    if (matrix[player1Row, player1Col] == player2Mark)
                    {
                        matrix[player1Row, player1Col] = dead;
                        IsDead = true;
                    }
                    else
                    {
                        matrix[player1Row, player1Col] = player1Mark;
                    }
                }
                else if (firstCommand == "up")
                {
                    player1Row--;
                    if (player1Row < 0)
                    {
                        player1Row = matrix.GetLength(0) - 1;
                    }
                    if (matrix[player1Row, player1Col] == player2Mark)
                    {
                        matrix[player1Row, player1Col] = dead;
                        IsDead = true;
                    }
                    else
                    {
                        matrix[player1Row, player1Col] = player1Mark;
                    }
                }
                else if (firstCommand == "down")
                {
                    player1Row++;
                    if (player1Row == matrix.GetLength(0))
                    {
                        player1Row = 0;
                    }
                    if (matrix[player1Row, player1Col] == player2Mark)
                    {
                        matrix[player1Row, player1Col] = dead;
                        IsDead = true;
                    }
                    else
                    {
                        matrix[player1Row, player1Col] = player1Mark;
                    }
                }

                if (IsDead)
                {
                    PrintMatrix(matrix);
                    return;
                }

                if (secondCommand == "left")
                {
                    player2Col--;
                    if (player2Col < 0)
                    {
                        player2Col = matrix.GetLength(1) - 1;
                    }
                    if (matrix[player2Row, player2Col] == player1Mark)
                    {
                        matrix[player2Row, player2Col] = dead;
                        IsDead = true;
                    }
                    else
                    {
                        matrix[player2Row, player2Col] = player2Mark;
                    }
                }
                else if (secondCommand == "right")
                {
                    player2Col++;
                    if (player2Col == matrix.GetLength(1))
                    {
                        player2Col = 0;
                    }
                    if (matrix[player2Row, player2Col] == player1Mark)
                    {
                        matrix[player2Row, player2Col] = dead;
                        IsDead = true;
                    }
                    else
                    {
                        matrix[player2Row, player2Col] = player2Mark;
                    }
                }

                else if (secondCommand == "up")
                {
                    player2Row--;
                    if (player2Row < 0)
                    {
                        player2Row = matrix.GetLength(0) - 1;
                    }
                    if (matrix[player2Row, player2Col] == player1Mark)
                    {
                        matrix[player2Row, player2Col] = dead;
                        IsDead = true;
                    }
                    else
                    {
                        matrix[player2Row, player2Col] = player2Mark;
                    }
                }

                else if (secondCommand == "down")
                {
                    player2Row++;
                    if (player2Col == matrix.GetLength(0))
                    {
                        player2Col = 0;
                    }
                    if (matrix[player2Row, player2Col] == player1Mark)
                    {
                        matrix[player2Row, player2Col] = dead;
                        IsDead = true;
                    }
                    else
                    {
                        matrix[player2Row, player2Col] = player2Mark;
                    }
                }

                if (IsDead)
                {
                    PrintMatrix(matrix);
                    return;
                }

            }
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
