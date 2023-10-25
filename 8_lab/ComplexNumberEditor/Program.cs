using ComplexNumberEditor;
using MyComplexNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumberEditor
{
    public class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber n = new ComplexNumber("1+1*i");
            Console.WriteLine(n.GetComplex());
            TEditor editor = new TEditor(n);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Вывод комплексного числа: " + editor.GetFullString());
                Console.WriteLine("Редактирование: " + (editor.IsEditingRealPart() ? "Действительная" : "Мнимая") + " часть");
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить цифру");
                Console.WriteLine("2. Добавить точку");
                Console.WriteLine("3. Добавить ноль");
                Console.WriteLine("4. Переключить область редактирования (Действительная / Мнимая часть)");
                Console.WriteLine("5. Изменить знак");
                Console.WriteLine("6. Удалить последний символ");
                Console.WriteLine("7. Очистить");
                Console.WriteLine("8. Выйти");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Введите цифру: ");
                            if (int.TryParse(Console.ReadLine(), out int digit))
                            {
                                editor.AddDigit(digit);
                            }
                            break;
                        case 2:
                            editor.AddSeporator(); // Добавить точку
                            break;
                        case 3:
                            editor.AddZero(); // Добавить ноль
                            break;
                        case 4:
                            editor.ChangeEditingZone(); // Переключить область редактирования
                            break;
                        case 5:
                            editor.AddSign(); // Изменить знак
                            break;
                        case 6:
                            editor.Pop(); // Удалить последний символ
                            break;
                        case 7:
                            editor.Clear(); // Очистить
                            break;
                        case 8:
                            Environment.Exit(0); // Выйти из программы
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте снова.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                }
            }
        }
    }
}

