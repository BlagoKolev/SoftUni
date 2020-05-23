using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2._2X2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var row = size[0];
            var col = size[1];

            var matrix = new char[row, col];

            for (int rows = 0; rows < row; rows++)
            {
                var line = Console.ReadLine().Split();

                for (int cols = 0; cols < col; cols++)
                {
                    matrix[rows, cols] = char.Parse(line[cols]);
                }
            }

            var counter = 0;
            for (int rows = 0; rows < row; rows++)
            {
                if (rows == row - 1)
                {
                    break;
                }
                for (int cols = 0; cols < col; cols++)
                {
                    if (cols == col - 1)
                    {
                        break;
                    }

                    if (matrix[rows, cols] == matrix[rows, cols + 1]
                        && matrix[rows, cols + 1] == matrix[rows + 1, cols]
                        && matrix[rows + 1, cols] == matrix[rows + 1, cols + 1])
                    {
                        counter++;
                    }


                }


            }
            Console.WriteLine(counter);
        }
    }
}
