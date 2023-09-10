using System;
using System.Collections.Generic;

namespace STP_ThirdLab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*double[] h = new double[3];
            h = Order(7, 3, 5);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(h[i]);
            }
            Console.WriteLine("");
            h = Order(4, 5, 6);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(h[i]);
            }
            Console.WriteLine("");
            h = Order(7, 5, 2);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(h[i]);
            }
            Console.WriteLine("");
            h = Order(1, 2, 3);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(h[i]);
            }
            Console.WriteLine("");

            Console.WriteLine(GCD(13, 576));

            Console.WriteLine(ConvertFromEven(436654));

            double[,] matrix = new double[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = i + j;
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine(" ");
            }

            MaxMatrixTopDiameterEl(matrix);*/
        }

        public static double[] Order(double x, double y, double z)
        {
            double[] order = new double[3];
            if (x < y)
            {
                (x, y) = (y, x);
            }
            if (y < z)
            {
                (y, z) = (z, y);
            }
            if (x < y)
            {
                (x, y) = (y, x);
            }
            order[0] = x; order[1] = y; order[2] = z;

            return order;
        }
        static int Min(int x, int y)
        {
            return x < y ? x : y;
        }

        static int Max(int x, int y)
        {
            return x > y ? x : y;
        }

        public static int GCD(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }
            else
            {
                var min = Min(a, b);
                var max = Max(a, b);
                return GCD(max - min, min);
            }
        }

        public static int ConvertFromEven(int x)
        {
            List<int> numbers = new List<int> { };
            while (x > 0)
            {
                numbers.Add((x % 10));
                x = x / 10;
            }



            int res = 0;
            int grade = 1;
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (numbers[i] % 2 == 0)
                {
                    res += numbers[i] * grade;
                    grade *= 10;
                }
            }

            Console.WriteLine(res);
            return res;
        }

        public static double MaxMatrixTopDiameterEl(double[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                throw new ArgumentException("Массив пустой или равен null.");
            }

            double res = double.MinValue;
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int shift = 0;

            for (int i = 0; i < rows; i++)
            {
                // Console.WriteLine("i: ");
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] % 2 == 1 && i < j)
                    {
                        // Console.Write(matrix[i, j] + " ");
                        res += matrix[i, j];
                    }
                }
                // Console.WriteLine("\n");
                shift++;
            }

            return res;
        }
    }
}
