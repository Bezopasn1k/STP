using System;

namespace STP_SecondLab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /* double[,] matrix = new double[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = i + j;
                }
            }
            Console.WriteLine(MinFromTwo(-425, 45));
            Console.WriteLine(MinFromTwo(5400, 5399));
            Console.WriteLine(MaxMatrixEl(matrix)); 
            Console.WriteLine(MaxMatrixTopDiameterEl(matrix)); */
        }

        public static double MinFromTwo(double first, double second)
        {
            return first < second ? first : second;
        }

        public static double MaxMatrixEl(double[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                throw new ArgumentException("Массив пустой или равен null.");
            }

            double maxEl = double.MinValue;
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] > maxEl)
                    {
                        maxEl = matrix[i, j];
                    }
                }
            }

            return maxEl;

        }

        public static double MaxMatrixTopDiameterEl(double[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                throw new ArgumentException("Массив пустой или равен null.");
            }

            double maxEl = double.MinValue;
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int shift = 0;

            for (int i = 0; i < rows; i++)
            {
                // Console.WriteLine("i: ");
                for (int j = 0; j < columns - shift; j++)
                {
                    // Console.Write(matrix[i, j] + " ");
                    if (matrix[i, j] > maxEl)
                    {
                        maxEl = matrix[i, j];
                    }
                }
                // Console.WriteLine("\n");
                shift++;
            }

            return maxEl;

        }
    }
}
