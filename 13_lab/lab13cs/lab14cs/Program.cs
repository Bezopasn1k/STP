using System;

class Program
{
    static void Main()
    {
        int[] n2Array = { 300, 400, 512 };
        int optimalN2 = 8;

        foreach (int n2 in n2Array)
        {
            double k = (double)n2 / optimalN2;

            int i = 0;
            if (k > 8)
            {
                i = (int)(Math.Log2(n2) / 3) + 1;
            }

            double K = 1;
            for (int j = 1; j < i; ++j)
            {
                K += (double)n2 / Math.Pow(8, j);
            }

            double N = K * n2 * Math.Log2(n2);

            double V = N * Math.Log2(2 * n2);

            double P = (3 * N) / 8;

            double Tk = P / (5 * 20);

            double B = V / 3000;

            double t = 0.5 / Math.Log(B);

            Console.WriteLine($"Value n2*: {n2}");
            Console.WriteLine($"Number of lower level modules: {k}");
            Console.WriteLine($"Number of hierarchy levels i: {i}");
            Console.WriteLine($"Number of modules in PS: {K}");
            Console.WriteLine($"Program length N: {N}");
            Console.WriteLine($"Volume V PS: {V}");
            Console.WriteLine($"Length of line in assembler commands P: {P}");
            Console.WriteLine($"Calendar programming time Tk: {Tk}");
            Console.WriteLine($"Initial number of errors B: {B}");
            Console.WriteLine($"PS reliability t: {t}\n");
        }
    }
}
