using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/*
 Write an algorithm such that if an element in an M*N matrix is 0, 
 * its entire row and column is set to 0.
 */

namespace MatrixProblems
{
    public class MatrixRowColSetZero
    {
        public static void Main(string[] args)
        {
            int row = 3, col = 3;
            int[,] matrix = new int[,]{{1,2,3}, {4,0,6}, {7,8,9}};


            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("");
            Console.WriteLine("Changed Matrix : \n");
            matrix = RowColSetZero(matrix, row, col);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine("");
            }


           Console.ReadLine();
        }

        public static int[,] RowColSetZero(int[,] matrix, int row, int col)
        {
            bool[] rowZero = new bool[row];
            bool[] colZero = new bool[col];

            for (int rowi = 0; rowi < row; rowi++)
            {
                for (int colj = 0; colj < col; colj++)
                {
                    if (matrix[rowi, colj] == 0)
                    {
                        rowZero[rowi] = true;
                        colZero[colj] = true;
                    }
                }
            }

            for (int i = 0; i < rowZero.Length; i++)
            {
                for (int colj = 0; colj < col; colj++)
                {
                    if (rowZero[i])
                        matrix[i, colj] = 0;
                }
            }

            for (int rowi = 0; rowi < row; rowi++)
            {
                for (int j = 0; j < colZero.Length; j++)
                {
                    if(colZero[j])
                        matrix[rowi, j] = 0;
                }
            }

            return matrix;
        }
    }
}