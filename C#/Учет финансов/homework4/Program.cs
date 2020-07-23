using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Оставляем место для вывода ошибок
            Console.WriteLine("Ошибки: ");
            // Создание массива для хранения доходов
            int[] income = new int[12];
            bool flag = false;
            byte heightline = 2;
            // Создаем позиции заголовков вручную для таблицы
            Console.SetCursorPosition((Console.WindowWidth / 6) - 5, (Console.WindowHeight / 100) + heightline - 1);
            Console.WriteLine("Доход, тыс. руб.");
            Console.SetCursorPosition(Console.WindowWidth / 100, (Console.WindowHeight / 100) + heightline - 1);
            Console.WriteLine("Месяц");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 7, (Console.WindowHeight / 100) + heightline - 1);
            Console.WriteLine("Расход, тыс. руб.");
            Console.SetCursorPosition((Console.WindowWidth / 2) + 18, (Console.WindowHeight / 100) + heightline - 1);
            Console.WriteLine("Прибыль, тыс. руб.");
            // Цикл позволяющий пользователю вводить данные доходности
            for (byte i = 0; i < 12; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 100, (Console.WindowHeight / 100) + heightline);
                // Счетчик месяцев
                Console.WriteLine($"{i + 1}");
                int income1 = 0;
                //Цикл проверяющий информацию которую вводит пользователь
                do
                {
                    Console.SetCursorPosition((Console.WindowWidth / 6) - 5, (Console.WindowHeight / 100) + heightline);
                    flag = int.TryParse(Console.ReadLine(), out income1);
                    if (!flag)
                    {
                        Console.SetCursorPosition((Console.WindowWidth / 100) + 9, Console.WindowHeight / 100);
                        Console.WriteLine("Программа принимает только числовые значения. Повторите ввод.");
                    }
                    else if (income1 < 0)
                    {
                        Console.SetCursorPosition((Console.WindowWidth / 100) + 9, Console.WindowHeight / 100);
                        Console.WriteLine("Доход не может быть отрицательным числом. Повторите ввод.    ");
                    }
                    else if (flag && income1 >= 0)
                    {
                        heightline++;
                        break;
                    }
                    } while (true);
                // Заполнение массива
                income[i] = income1;
            }
            heightline -= 14;

            // Создание массива для хранения расходов
            int[] costs = new int[12];
            int costs1 = 0;
            bool flag1 = false;
            // Цикл проверяющий информацию которую вводит пользователь
            for (byte i = 0; i < 12; i++)
            {
                do
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 7, (Console.WindowHeight / 10) + heightline);
                    flag1 = int.TryParse(Console.ReadLine(), out costs1);
                    if (!flag1)
                    {
                        Console.SetCursorPosition((Console.WindowWidth / 100) + 9, Console.WindowHeight / 100);
                        Console.WriteLine("Программа принимает только числовые значения. Повторите ввод.");
                    }
                    if (costs1 < 0)
                    {
                        Console.SetCursorPosition((Console.WindowWidth / 100) + 9, Console.WindowHeight / 100);
                        Console.WriteLine("Расход не может быть отрицательным числом. Повторите ввод.       ");
                    }
                    else if (flag1 && costs1 >= 0)
                    {
                        heightline++;
                        break;
                    }
                } while (true);
                // Заполнение массива
                costs[i] = costs1;
            }
            heightline -= 10;

            // Вычитаем массив расходов от массива доходов и выводим результат в консоль 
            for (int i = 0; i < 12; i++)
            {
                income[i] -= costs[i];
                Console.SetCursorPosition((Console.WindowWidth / 2) + 18, (Console.WindowHeight / 100) + heightline);
                Console.WriteLine($"{income[i]}");
                heightline++;
            }

            //Создаем третий массив и копируем содержимое массива доходов
            int[] month = new int[12];
            Array.ConstrainedCopy(income, 0, month, 0, 12);
            byte successmonth = 0;
            //Цикл считающий количество месяц с прибылью
            for (byte i = 0; i < 12; i++)
            {
                if (income[i] > 0) successmonth++;
            }
            Console.SetCursorPosition(Console.WindowWidth / 100, (Console.WindowHeight / 100) + heightline + 1);
            Console.WriteLine($"Месяцев с положительной прибылью: {successmonth}");

            Console.SetCursorPosition(Console.WindowWidth / 100, (Console.WindowHeight / 100) + heightline + 2);
            Console.WriteLine($"Худшая прибыль в месяцы:");
            // Сортируем третий массив
            Array.Sort(month);
            byte index = 0;
            byte position = 0;
            // Цикл нахождения худших месяцев
            for (byte i = 0; i < 3; i++)
            {
                int result = Array.IndexOf(income, month[index]);
                Console.SetCursorPosition((Console.WindowWidth / 100) + 25 + position, (Console.WindowHeight / 100) + heightline + 2);
                Console.Write($"{result + 1}");
                position += 3;
                income[result] *= 0;
                income[result] += int.MaxValue;
                if (index == 11) break;
                if (month[index] == month[index + 1]) i--;
                index++;
            }
            Console.SetCursorPosition(Console.WindowWidth / 100, (Console.WindowHeight / 100) + heightline + 3);
            Console.WriteLine("Нажмите любую кнопку, чтобы выйти");
            Console.ReadKey();
        }
    }
}
