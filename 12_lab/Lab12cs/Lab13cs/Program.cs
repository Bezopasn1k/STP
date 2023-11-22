using System;

class Program
{
    static void Main()
    {
        Console.WriteLine();
        one();
        Console.WriteLine();
        two();
        Console.WriteLine();
        three();
        Console.WriteLine();
        four();
        Console.WriteLine();
        five();
        Console.WriteLine();
        six();
        Console.WriteLine();
        seven();
    }

    static int BinarySearch(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] == target)
            {
                return mid;
            }
            else if (arr[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }

    static void CyclicShiftLeft(int[] arr, int positions)
    {
        int n = arr.Length;

        positions = positions % n;

        for (int i = 0; i < positions; i++)
        {
            int temp = arr[0];
            for (int j = 0; j < n - 1; j++)
            {
                arr[j] = arr[j + 1];
            }
            arr[n - 1] = temp;
        }
    }

    static void ReplaceValue(int[] arr, int target, int replacement)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
            {
                arr[i] = replacement;
            }
        }
    }

    static (int minVal, int minIndex) FindMin(int[] arr)
    {
        int minVal = arr[0];
        int minIndex = 0;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < minVal)
            {
                minVal = arr[i];
                minIndex = i;
            }
        }

        return (minVal, minIndex);
    }

    static void ReverseArray(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n / 2; i++)
        {
            int temp = arr[i];
            arr[i] = arr[n - i - 1];
            arr[n - i - 1] = temp;
        }
    }

    static (double min_value, (int min_i, int min_j) min_index) FindMin2D(int[][] arr)
    {
        double min_value = double.PositiveInfinity;
        (int min_i, int min_j) min_index = (-1, -1);

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                if (arr[i][j] < min_value)
                {
                    min_value = arr[i][j];
                    min_index = (i, j);
                }
            }
        }

        return (min_value, min_index);
    }

    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n; i++)
        {
            bool swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }

            if (!swapped)
            {
                break;
            }
        }
    }

    static void one()
    {
        Console.WriteLine("1.Find the minimum element of a one-dimensional array");
        Console.WriteLine(" integers, its value and the value of its index");
        
        int eta = 4;
        int n1 = 10;
        int n2 = 8;
        int n = n1 + n2;

        int N1 = 19;
        int N2 = 22;
        int N = N1 + N2;
        
        int S = 15;

        // потенциальный объем реализации
        double VV = (2 + eta) * Math.Log(2 + eta, 2);         // в битах

        // объём реализации
        double V = N * Math.Log(n, 2);                        // в битах

        // уровень программы через потенциальный объем
        double L = VV / V;

        // уровень программы по реализации
        double LL = (Convert.ToDouble(n1) / N1) * (Convert.ToDouble(n2) / N2);

        // интеллектуальное содержание программы
        double I = LL * V;

        // прогнозируемое время написания программы, выраженное через потенциальный объем
        double T1 = (V * V) / (S * VV);

        // прогнозируемое время написания программы, выраженное через длину реализации, найденную по Холстеду
        double T2 = (n2 * N2 * (n1 * Math.Log(n1, 2) + n2 * Math.Log(n2, 2)) * Math.Log(n, 2)) / (2 * S * n2);

        // прогнозируемое время написания программы, выраженное через метрические характеристики реализации
        double T3 = (n1 * N2 * N * Math.Log(n, 2)) / (2 * S * n2);

        // среднее значение уровня языка программирования
        double l = L * L * V;

        Console.WriteLine($"Potential Sales Volume (VV): {VV}");
        Console.WriteLine($"Volume of implementation (V): {V}");
        Console.WriteLine($"Program level through potential volume (L): {L}");
        Console.WriteLine($"Implementation Program Level (LL): {LL}");
        Console.WriteLine($"Intellectual content of the program (I): {I}");
        Console.WriteLine($"Predicted program writing time expressed in terms of potential volume (T1): {T1}");
        Console.WriteLine($"Predicted time to write the program, expressed in terms of the implementation length found by Halstead (T2): {T2}");
        Console.WriteLine($"Predicted time to write a program, expressed in terms of implementation metric characteristics (T3): {T3}");
        Console.WriteLine($"Average programming language level: {l}");
    }

    static void two()
    {
        Console.WriteLine("2. Sort a one-dimensional array in ascending order");
        Console.WriteLine(" bubble method\n");

        int eta = 3;
        int n1 = 15;
        int n2 = 15;
        int n = n1 + n2;

        int N1 = 32;
        int N2 = 29;
        int N = N1 + N2;
        
        int S = 15;

        // потенциальный объем реализации
        double VV = (2 + eta) * Math.Log(2 + eta, 2);         // в битах

        // объём реализации
        double V = N * Math.Log(n, 2);                        // в битах

        // уровень программы через потенциальный объем
        double L = VV / V;

        // уровень программы по реализации
        double LL = (Convert.ToDouble(n1) / N1) * (Convert.ToDouble(n2) / N2);

        // интеллектуальное содержание программы
        double I = LL * V;

        // прогнозируемое время написания программы, выраженное через потенциальный объем
        double T1 = (V * V) / (S * VV);

        // прогнозируемое время написания программы, выраженное через длину реализации, найденную по Холстеду
        double T2 = (n2 * N2 * (n1 * Math.Log(n1, 2) + n2 * Math.Log(n2, 2)) * Math.Log(n, 2)) / (2 * S * n2);

        // прогнозируемое время написания программы, выраженное через метрические характеристики реализации
        double T3 = (n1 * N2 * N * Math.Log(n, 2)) / (2 * S * n2);

        // среднее значение уровня языка программирования
        double l = L * L * V;

        Console.WriteLine($"Potential Sales Volume (VV): {VV}");
        Console.WriteLine($"Volume of implementation (V): {V}");
        Console.WriteLine($"Program level through potential volume (L): {L}");
        Console.WriteLine($"Implementation Program Level (LL): {LL}");
        Console.WriteLine($"Intellectual content of the program (I): {I}");
        Console.WriteLine($"Predicted program writing time expressed in terms of potential volume (T1): {T1}");
        Console.WriteLine($"Predicted time to write the program, expressed in terms of the implementation length found by Halstead (T2): {T2}");
        Console.WriteLine($"Predicted time to write a program, expressed in terms of implementation metric characteristics (T3): {T3}");
        Console.WriteLine($"Average programming language level: {l}");
    }

    static void three()
    {
        Console.WriteLine("3. Binary search for an element in an ordered one-dimensional");
        Console.WriteLine(" array\n");

        int eta = 5;
        int n1 = 15;
        int n2 = 12;
        int n = n1 + n2;

        int N1 = 32;
        int N2 = 29;
        int N = N1 + N2;
        
        int S = 15;

        // потенциальный объем реализации
        double VV = (2 + eta) * Math.Log(2 + eta, 2);         // в битах

        // объём реализации
        double V = N * Math.Log(n, 2);                        // в битах

        // уровень программы через потенциальный объем
        double L = VV / V;

        // уровень программы по реализации
        double LL = (Convert.ToDouble(n1) / N1) * (Convert.ToDouble(n2) / N2);

        // интеллектуальное содержание программы
        double I = LL * V;

        // прогнозируемое время написания программы, выраженное через потенциальный объем
        double T1 = (V * V) / (S * VV);

        // прогнозируемое время написания программы, выраженное через длину реализации, найденную по Холстеду
        double T2 = (n2 * N2 * (n1 * Math.Log(n1, 2) + n2 * Math.Log(n2, 2)) * Math.Log(n, 2)) / (2 * S * n2);

        // прогнозируемое время написания программы, выраженное через метрические характеристики реализации
        double T3 = (n1 * N2 * N * Math.Log(n, 2)) / (2 * S * n2);

        // среднее значение уровня языка программирования
        double l = L * L * V;

        Console.WriteLine($"Potential Sales Volume (VV): {VV}");
        Console.WriteLine($"Volume of implementation (V): {V}");
        Console.WriteLine($"Program level through potential volume (L): {L}");
        Console.WriteLine($"Implementation Program Level (LL): {LL}");
        Console.WriteLine($"Intellectual content of the program (I): {I}");
        Console.WriteLine($"Predicted program writing time expressed in terms of potential volume (T1): {T1}");
        Console.WriteLine($"Predicted time to write the program, expressed in terms of the implementation length found by Halstead (T2): {T2}");
        Console.WriteLine($"Predicted time to write a program, expressed in terms of implementation metric characteristics (T3): {T3}");
        Console.WriteLine($"Average programming language level: {l}");
    }

    static void four()
    {
        Console.WriteLine("4. Find the minimum element of a two-dimensional array");
        Console.WriteLine(" integer, its value and the value of its indices.\n");

        int eta = 5;
        int n1 = 11;
        int n2 = 12;
        int n = n1 + n2;

        int N1 = 32;
        int N2 = 38;
        int N = N1 + N2;
        
        int S = 15;

        // потенциальный объем реализации
        double VV = (2 + eta) * Math.Log(2 + eta, 2);         // в битах

        // объём реализации
        double V = N * Math.Log(n, 2);                        // в битах

        // уровень программы через потенциальный объем
        double L = VV / V;

        // уровень программы по реализации
        double LL = (Convert.ToDouble(n1) / N1) * (Convert.ToDouble(n2) / N2);

        // интеллектуальное содержание программы
        double I = LL * V;

        // прогнозируемое время написания программы, выраженное через потенциальный объем
        double T1 = (V * V) / (S * VV);

        // прогнозируемое время написания программы, выраженное через длину реализации, найденную по Холстеду
        double T2 = (n2 * N2 * (n1 * Math.Log(n1, 2) + n2 * Math.Log(n2, 2)) * Math.Log(n, 2)) / (2 * S * n2);

        // прогнозируемое время написания программы, выраженное через метрические характеристики реализации
        double T3 = (n1 * N2 * N * Math.Log(n, 2)) / (2 * S * n2);

        // среднее значение уровня языка программирования
        double l = L * L * V;

        Console.WriteLine($"Potential Sales Volume (VV): {VV}");
        Console.WriteLine($"Volume of implementation (V): {V}");
        Console.WriteLine($"Program level through potential volume (L): {L}");
        Console.WriteLine($"Implementation Program Level (LL): {LL}");
        Console.WriteLine($"Intellectual content of the program (I): {I}");
        Console.WriteLine($"Predicted program writing time expressed in terms of potential volume (T1): {T1}");
        Console.WriteLine($"Predicted time to write the program, expressed in terms of the implementation length found by Halstead (T2): {T2}");
        Console.WriteLine($"Predicted time to write a program, expressed in terms of implementation metric characteristics (T3): {T3}");
        Console.WriteLine($"Average programming language level: {l}");
    }

    static void five()
    {
        Console.WriteLine("5. Rearrange element values");
        Console.WriteLine(" one-dimensional array in reverse order.\n");

        int eta = 3;
        int n1 = 10;
        int n2 = 9;
        int n = n1 + n2;

        int N1 = 20;
        int N2 = 24;
        int N = N1 + N2;
        
        int S = 15;

        // потенциальный объем реализации
        double VV = (2 + eta) * Math.Log(2 + eta, 2);         // в битах

        // объём реализации
        double V = N * Math.Log(n, 2);                        // в битах

        // уровень программы через потенциальный объем
        double L = VV / V;

        // уровень программы по реализации
        double LL = (Convert.ToDouble(n1) / N1) * (Convert.ToDouble(n2) / N2);

        // интеллектуальное содержание программы
        double I = LL * V;

        // прогнозируемое время написания программы, выраженное через потенциальный объем
        double T1 = (V * V) / (S * VV);

        // прогнозируемое время написания программы, выраженное через длину реализации, найденную по Холстеду
        double T2 = (n2 * N2 * (n1 * Math.Log(n1, 2) + n2 * Math.Log(n2, 2)) * Math.Log(n, 2)) / (2 * S * n2);

        // прогнозируемое время написания программы, выраженное через метрические характеристики реализации
        double T3 = (n1 * N2 * N * Math.Log(n, 2)) / (2 * S * n2);

        // среднее значение уровня языка программирования
        double l = L * L * V;

        Console.WriteLine($"Potential Sales Volume (VV): {VV}");
        Console.WriteLine($"Volume of implementation (V): {V}");
        Console.WriteLine($"Program level through potential volume (L): {L}");
        Console.WriteLine($"Implementation Program Level (LL): {LL}");
        Console.WriteLine($"Intellectual content of the program (I): {I}");
        Console.WriteLine($"Predicted program writing time expressed in terms of potential volume (T1): {T1}");
        Console.WriteLine($"Predicted time to write the program, expressed in terms of the implementation length found by Halstead (T2): {T2}");
        Console.WriteLine($"Predicted time to write a program, expressed in terms of implementation metric characteristics (T3): {T3}");
        Console.WriteLine($"Average programming language level: {l}");
    }

    static void six()
    {
        Console.WriteLine("6. Cycle elements");
        Console.WriteLine(" one-dimensional array to the specified number of positions to the left\n");

        int eta = 4;
        int n1 = 11;
        int n2 = 13;
        int n = n1 + n2;

        int N1 = 25;
        int N2 = 31;
        int N = N1 + N2;
        
        int S = 15;

        // потенциальный объем реализации
        double VV = (2 + eta) * Math.Log(2 + eta, 2);         // в битах

        // объём реализации
        double V = N * Math.Log(n, 2);                        // в битах

        // уровень программы через потенциальный объем
        double L = VV / V;

        // уровень программы по реализации
        double LL = (Convert.ToDouble(n1) / N1) * (Convert.ToDouble(n2) / N2);

        // интеллектуальное содержание программы
        double I = LL * V;

        // прогнозируемое время написания программы, выраженное через потенциальный объем
        double T1 = (V * V) / (S * VV);

        // прогнозируемое время написания программы, выраженное через длину реализации, найденную по Холстеду
        double T2 = (n2 * N2 * (n1 * Math.Log(n1, 2) + n2 * Math.Log(n2, 2)) * Math.Log(n, 2)) / (2 * S * n2);

        // прогнозируемое время написания программы, выраженное через метрические характеристики реализации
        double T3 = (n1 * N2 * N * Math.Log(n, 2)) / (2 * S * n2);

        // среднее значение уровня языка программирования
        double l = L * L * V;

        Console.WriteLine($"Potential Sales Volume (VV): {VV}");
        Console.WriteLine($"Volume of implementation (V): {V}");
        Console.WriteLine($"Program level through potential volume (L): {L}");
        Console.WriteLine($"Implementation Program Level (LL): {LL}");
        Console.WriteLine($"Intellectual content of the program (I): {I}");
        Console.WriteLine($"Predicted program writing time expressed in terms of potential volume (T1): {T1}");
        Console.WriteLine($"Predicted time to write the program, expressed in terms of the implementation length found by Halstead (T2): {T2}");
        Console.WriteLine($"Predicted time to write a program, expressed in terms of implementation metric characteristics (T3): {T3}");
        Console.WriteLine($"Average programming language level: {l}");
    }

    static void seven()
    {
        Console.WriteLine("7. Replace all occurrences of an integer value with");
        Console.WriteLine(" integer array\n");

        int eta = 5;
        int n1 = 10;
        int n2 = 6;
        int n = n1 + n2;

        int N1 = 14;
        int N2 = 15;
        int N = N1 + N2;
        
        int S = 15;

        // потенциальный объем реализации
        double VV = (2 + eta) * Math.Log(2 + eta, 2);         // в битах

        // объём реализации
        double V = N * Math.Log(n, 2);                        // в битах

        // уровень программы через потенциальный объем
        double L = VV / V;

        // уровень программы по реализации
        double LL = (Convert.ToDouble(n1) / N1) * (Convert.ToDouble(n2) / N2);

        // интеллектуальное содержание программы
        double I = LL * V;

        // прогнозируемое время написания программы, выраженное через потенциальный объем
        double T1 = (V * V) / (S * VV);

        // прогнозируемое время написания программы, выраженное через длину реализации, найденную по Холстеду
        double T2 = (n2 * N2 * (n1 * Math.Log(n1, 2) + n2 * Math.Log(n2, 2)) * Math.Log(n, 2)) / (2 * S * n2);

        // прогнозируемое время написания программы, выраженное через метрические характеристики реализации
        double T3 = (n1 * N2 * N * Math.Log(n, 2)) / (2 * S * n2);

        // среднее значение уровня языка программирования
        double l = L * L * V;

        Console.WriteLine($"Potential Sales Volume (VV): {VV}");
        Console.WriteLine($"Volume of implementation (V): {V}");
        Console.WriteLine($"Program level through potential volume (L): {L}");
        Console.WriteLine($"Implementation Program Level (LL): {LL}");
        Console.WriteLine($"Intellectual content of the program (I): {I}");
        Console.WriteLine($"Predicted program writing time expressed in terms of potential volume (T1): {T1}");
        Console.WriteLine($"Predicted time to write the program, expressed in terms of the implementation length found by Halstead (T2): {T2}");
        Console.WriteLine($"Predicted time to write a program, expressed in terms of implementation metric characteristics (T3): {T3}");
        Console.WriteLine($"Average programming language level: {l}");
    }
}
