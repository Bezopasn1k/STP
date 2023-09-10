using System;

namespace STP_ThirdLab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double[] h = new double[3];
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

            Console.WriteLine(GCD(-13, -576));

            Console.WriteLine(ConvertFromEven(-12345678));

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

            MaxMatrixTopDiameterEl(matrix);
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

        public static int GCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == 0)
            {
                return b;
            }
            else
            {
                var min = Math.Min(a, b);
                var max = Math.Max(a, b);
                return GCD(max - min, min);
            }
        }

        public static int ConvertFromEven(int x)
        {
            x = Math.Abs(x);
            int result = 0;
            int grade = 1;
            bool evenDigit = false;

            while (x > 0)
            {
                int digit = x % 10;
                if (evenDigit)
                {
                    result += digit * grade;
                    grade *= 10;
                }
                evenDigit = !evenDigit;
                x = x / 10;
            }

            return result;
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
