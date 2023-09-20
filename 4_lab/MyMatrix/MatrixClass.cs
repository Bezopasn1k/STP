using System;
namespace ConsoleApplicationMatrix
{
    public class MyException : Exception
    {
        public MyException(string s) : base(s) { }
    }
    public class MatrixClass
    {
        int[,] m;
        //Свойство для работы с числом строк.
        public int I { get; }
        //Свойство для работы с числом столбцов.
        public int J { get; }
        //Конструктор (i, j).
        public MatrixClass(int i, int j)
        {
            if (i <= 0)
                throw new MyException($"недопустимое значение строки ={i}");
            if (j <= 0)
                throw new MyException($"недопустимое значение столбца= {j}");
            I = i;
            J = j;
            m = new int[i, j];
        }
        // Конструктор (matrix, i, j)
        public MatrixClass(int[,] matrix, int i, int j)
        {
            if (i <= 0)
                throw new MyException($"недопустимое значение строки ={i}");
            if (j <= 0)
                throw new MyException($"недопустимое значение столбца= {j}");
            I = i;
            J = j;
            m = new int[i, j];
            for (int k = 0; k < I; k++)
            {
                for (int l = 0; l < J; l++)
                {
                    m[k, l] = matrix[k, l];
                }
            }
        }
        //Индексатор для доступа к значениям компонентов матрицы.
        public int this[int i, int j]
        {
            get
            {
                if (i < 0 | i > I - 1)
                    throw new MyException($"неверное значение i = {i}");
                if (j < 0 | j > J - 1)
                    throw new MyException($"неверное значение j = {j}");
                return m[i, j];
            }
            set
            {
                if (i < 0 | i > I - 1)
                    throw new MyException($"неверное значение i = {i}");
                if (j < 0 | j > J - 1)
                    throw new MyException($"неверное значение j = {j}");
                m[i, j] = value;
            }
        }
        //Сложение матриц.
        public static MatrixClass operator +(MatrixClass a, MatrixClass b)
        {
            if (a.I != b.I || a.J != b.J)
            {
                return null;
            }
            MatrixClass c = new MatrixClass(a.I, a.J);
            for (int i = 0; i < a.I; i++)
                for (int j = 0; j < a.J; j++)
                {
                    c[i, j] = a.m[i, j] + b.m[i, j];
                }
            return c;
        }
        //Вычетание матриц.
        public static MatrixClass operator -(MatrixClass a, MatrixClass b)
        {
            if (a.I != b.I || a.J != b.J)
            {
                return null;
            }
            MatrixClass c = new MatrixClass(a.I, a.J);
            for (int i = 0; i < a.I; i++)
                for (int j = 0; j < a.J; j++)
                {
                    c[i, j] = a.m[i, j] - b.m[i, j];
                }
            return c;
        }
        //Умножение матриц
        public static MatrixClass operator *(MatrixClass a, MatrixClass b)
        {
            if (a.J != b.I)
            {
                return null;
            }
            MatrixClass c = new MatrixClass(b.J, a.I);
            for (int i = 0; i < c.I; i++)
            {
                for (int j = 0; j < c.J; j++)
                {
                    c[i, j] = 0;
                    for (int k = 0; k < b.I; k++)
                        c[i, j] += a[i, k] * b[k, j];
                }
            }
            return c;
        }
        public static bool operator ==(MatrixClass a, MatrixClass b)
        {
            bool q = true;
            for (int i = 0; i < a.I; i++)
                for (int j = 0; j < a.J; j++)
                {
                    if (a[i, j] != b[i, j])
                    {
                        q = false; break;
                    }
                }
            return q;
        }
        public static bool operator !=(MatrixClass a, MatrixClass b)
        {
            return !(a == b);
        }
        //Вывод значений компонентов на консоль.
        public void Show()
        {
            for (int i = 0; i < I; i++)
            {
                for (int j = 0; j < J; j++)
                {
                    Console.Write("\t" + this[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public override bool Equals(object obj)
        {
            return (this as MatrixClass) == (obj as MatrixClass);
        }

        public int GetI()
        {
            return I;
        }

        public int GetJ()
        {
            return J;
        }

        public override string ToString()
        {
            string result = "{";
            for (int i = 0; i < I; i++)
            {
                result += "{";
                for (int j = 0; j < J; j++)
                {
                    if (j + 1 == J)
                    {
                        result += m[i, j].ToString();
                    }
                    else
                    {
                        result += m[i, j].ToString() + ',';
                    }
                }
                if (i + 1 == I)
                {
                    result += "}";
                }
                else
                {
                    result += "} ";
                }
            }
            result += "}";

            return result;
        }

        public int Min()
        {
            int min = int.MaxValue;
            for (int i = 0; i < I; i++)
            {
                for (int j = 0; j < J; j++)
                {
                    if (m[i, j] < min)
                    {
                        min = m[i, j];
                    }
                }
            }

            return min;
        }

        public MatrixClass Transp()
        {
            MatrixClass transpMatrix = new MatrixClass(I, J);
            for (int i = 0; i < I; i++)
            {
                for (int j = 0; j < J; j++)
                {
                    transpMatrix[i, j] = m[j, i];
                }
            }

            return transpMatrix;
        }
    }
}
