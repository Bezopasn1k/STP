using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplicationMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Создаём матрицу a.
                MatrixClass a = new MatrixClass(4, 3);
                //Создаём матрицу b.
                MatrixClass b = new MatrixClass(3, 4);
                //Объявляем матрицу c.
                MatrixClass c;
                //Заполняем матрицу a.
                for (int i = 0; i < a.I; i++)
                {
                    for (int j = 0; j < a.J; j++)
                    {
                        a[i, j] = a.J * i + j;
                    }
                }
                //Выводим матрицу a.
                a.Show();
                //Заполняем матрицу b.
                for (int i = 0; i < b.I; i++)
                {
                    for (int j = 0; j < b.J; j++)
                    {
                        b[i, j] = b.J * i + j + 1;
                    }
                }
                //Выводим матрицу a.
                b.Show();
                //Складываем матрицы a и b.
                // c = a + b;
                //Выводим матрицу c.
                // c.Show();
                c = a * b;
                c.Show();
                Console.WriteLine();
                Console.WriteLine(c.ToString());
                b = c.Transp();
                b.Show();
            }
            catch (MyException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}