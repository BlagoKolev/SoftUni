using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.PresentDelivery
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var presentsCount = int.Parse(Console.ReadLine());
            var size = int.Parse(Console.ReadLine());
            var rows = size;
            var cols = size;
            var matrix = new char[rows, cols];

            var santaRow = 0;
            var santaCol = 0;
            var niceKidsCount = 0;

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine().Split();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = char.Parse(line[col]);

                    if (matrix[row, col] == 'S')
                    {
                        santaRow = row;
                        santaCol = col;
                    }
                    if (matrix[row, col] == 'V')
                    {
                        niceKidsCount++;
                    }
                }
            }
            matrix[santaRow, santaCol] = '-';
            while (presentsCount > 0)
            {
                var command = Console.ReadLine();

                if (command == "Christmas morning")
                {
                    break;
                }

                if (command == "left")
                {


                    santaCol--;
                    if (santaCol < 0)
                    {
                        santaCol = matrix.GetLength(1) - 1;

                    }

                    if (matrix[santaRow, santaCol] == 'V')
                    {
                        matrix[santaRow, santaCol] = '-';
                        presentsCount--;
                    }
                    if (matrix[santaRow, santaCol] == 'X')
                    {
                        matrix[santaRow, santaCol] = '-';
                    }
                    if (matrix[santaRow, santaCol] == 'C')
                    {
                        if (matrix[santaRow - 1, santaCol] == 'V'
                            || matrix[santaRow - 1, santaCol] == 'X')
                        {
                            matrix[santaRow - 1, santaCol] = '-';
                            presentsCount--;
                            if (presentsCount == 0)
                            {
                                break;
                            }
                        }


                        if (matrix[santaRow + 1, santaCol] == 'V'
                                || matrix[santaRow + 1, santaCol] == 'X')
                        {
                            matrix[santaRow + 1, santaCol] = '-';
                            presentsCount--;
                            if (presentsCount == 0)
                            {
                                break;
                            }
                        }

                        if (matrix[santaRow, santaCol - 1] == 'V'
                                || matrix[santaRow, santaCol - 1] == 'X')
                        {
                            matrix[santaRow, santaCol - 1] = '-';
                            presentsCount--;
                            if (presentsCount == 0)
                            {
                                break;
                            }
                        }

                        if (matrix[santaRow, santaCol + 1] == 'V'
                                || matrix[santaRow, santaCol + 1] == 'X')
                        {
                            matrix[santaRow, santaCol + 1] = '-';
                            presentsCount--;
                            if (presentsCount == 0)
                            {
                                break;
                            }
                        }
                    }
                }
                if (command == "right")
                {
                    santaCol++;

                    if (santaCol == matrix.GetLength(1))
                    {
                        santaCol = 0;
                    }

                    if (matrix[santaRow, santaCol] == 'V')
                    {
                        matrix[santaRow, santaCol] = '-';
                        presentsCount--;
                    }

                    if (matrix[santaRow, santaCol] == 'X')
                    {
                        matrix[santaRow, santaCol] = '-';
                    }

                    if (matrix[santaRow, santaCol] == 'C')
                    {
                        if (matrix[santaRow - 1, santaCol] == 'V'
                            || matrix[santaRow - 1, santaCol] == 'X')
                        {
                            matrix[santaRow - 1, santaCol] = '-';
                            presentsCount--;
                            if (presentsCount == 0)
                            {
                                break;
                            }
                        }


                        if (matrix[santaRow + 1, santaCol] == 'V'
                                || matrix[santaRow + 1, santaCol] == 'X')
                        {
                            matrix[santaRow + 1, santaCol] = '-';
                            presentsCount--;
                            if (presentsCount == 0)
                            {
                                break;
                            }
                        }

                        if (matrix[santaRow, santaCol - 1] == 'V'
                                || matrix[santaRow, santaCol - 1] == 'X')
                        {
                            matrix[santaRow, santaCol - 1] = '-';
                            presentsCount--;
                            if (presentsCount == 0)
                            {
                                break;
                            }
                        }

                        if (matrix[santaRow, santaCol + 1] == 'V'
                                || matrix[santaRow, santaCol + 1] == 'X')
                        {
                            matrix[santaRow, santaCol + 1] = '-';
                            presentsCount--;
                            if (presentsCount == 0)
                            {
                                break;
                            }
                        }
                    }
                }
                if (command == "up")
                {


                    santaRow--;

                    if (santaRow < 0)
                    {
                        santaRow = matrix.GetLength(0) - 1;
                    }

                    if (matrix[santaRow, santaCol] == 'V')
                    {
                        matrix[santaRow, santaCol] = '-';
                        presentsCount--;
                    }

                    if (matrix[santaRow, santaCol] == 'X')
                    {
                        matrix[santaRow, santaCol] = '-';
                    }

                    if (matrix[santaRow, santaCol] == 'C')
                    {
                        if (matrix[santaRow - 1, santaCol] == 'V'
                            || matrix[santaRow - 1, santaCol] == 'X')
                        {
                            matrix[santaRow - 1, santaCol] = '-';
                            presentsCount--;
                            if (presentsCount == 0)
                            {
                                break;
                            }
                        }


                        if (matrix[santaRow + 1, santaCol] == 'V'
                                || matrix[santaRow + 1, santaCol] == 'X')
                        {
                            matrix[santaRow + 1, santaCol] = '-';
                            presentsCount--;
                            if (presentsCount == 0)
                            {
                                break;
                            }
                        }

                        if (matrix[santaRow, santaCol - 1] == 'V'
                                || matrix[santaRow, santaCol - 1] == 'X')
                        {
                            matrix[santaRow, santaCol - 1] = '-';
                            presentsCount--;
                            if (presentsCount == 0)
                            {
                                break;
                            }
                        }

                        if (matrix[santaRow, santaCol + 1] == 'V'
                                || matrix[santaRow, santaCol + 1] == 'X')
                        {
                            matrix[santaRow, santaCol + 1] = '-';
                            presentsCount--;
                            if (presentsCount == 0)
                            {
                                break;
                            }
                        }
                    }
                }
                if (command == "down")
                {
                    if (santaRow == matrix.GetLength(0))
                    {
                        santaRow = 0;
                    }

                    santaRow++;

                    if (matrix[santaRow, santaCol] == 'V')
                    {
                        matrix[santaRow, santaCol] = '-';
                        presentsCount--;
                    }

                    if (matrix[santaRow, santaCol] == 'X')
                    {
                        matrix[santaRow, santaCol] = '-';
                    }

                    if (matrix[santaRow, santaCol] == 'C')
                    {
                        if (matrix[santaRow - 1, santaCol] == 'V'
                            || matrix[santaRow - 1, santaCol] == 'X')
                        {
                            matrix[santaRow - 1, santaCol] = '-';
                            presentsCount--;
                            if (presentsCount == 0)
                            {
                                break;
                            }
                        }


                        if (matrix[santaRow + 1, santaCol] == 'V'
                                || matrix[santaRow + 1, santaCol] == 'X')
                        {
                            matrix[santaRow + 1, santaCol] = '-';
                            presentsCount--;
                            if (presentsCount == 0)
                            {
                                break;
                            }
                        }

                        if (matrix[santaRow, santaCol - 1] == 'V'
                                || matrix[santaRow, santaCol - 1] == 'X')
                        {
                            matrix[santaRow, santaCol - 1] = '-';
                            presentsCount--;
                            if (presentsCount == 0)
                            {
                                break;
                            }
                        }

                        if (matrix[santaRow, santaCol + 1] == 'V'
                                || matrix[santaRow, santaCol + 1] == 'X')
                        {
                            matrix[santaRow, santaCol + 1] = '-';
                            presentsCount--;
                            if (presentsCount == 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }//While LOOP Ends
            matrix[santaRow, santaCol] = 'S';
            if (presentsCount == 0)
            {
                Console.WriteLine("Santa ran out of presents!");
            }

            PrintMatrix(matrix);

            var result = CheckForV(matrix);
            if (result[0] == 0)
            {
                Console.WriteLine("Good job, Santa! {0} happy nice kid/s.", niceKidsCount);
            }
            else
            {
                Console.WriteLine("No presents for {0} nice kid/s.", result[1]);
            }

        }
        public static int[] CheckForV(char[,] matrix)
        {
            var result = new int[2];
            var hasV = 0; //false
            var vCount = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLongLength(1); col++)
                {
                    var symbol = matrix[row, col];
                    if (symbol == 'V')
                    {
                        hasV = 1; //true
                        vCount++;
                    }
                }
            }
            result[0] = hasV;
            result[1] = vCount;
            return result;
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLongLength(1); col++)
                {
                    Console.Write("{0} ", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}