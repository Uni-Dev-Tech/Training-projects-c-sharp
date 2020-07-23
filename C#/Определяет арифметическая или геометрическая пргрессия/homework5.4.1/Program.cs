using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5._4._1
{
    class Program
    {
        /// <summary>
        /// Метод определяющий арифметическую/геометрическую прогрессию заданной последовательности чисел состоящих в массиве
        /// </summary>
        /// <param name="Somenumbers">массив с числами</param>
        /// <returns></returns>
        static int Recognizer(int[] Somenumbers)
        {
            //Нахождение шага/разности прогрессии
            int algtest = Somenumbers[1] - Somenumbers[0];
            //Переменная для сравнения
            int test = 0;
            int test1 = 0;
            //Переменная для сохранение вывода
            int conclusion = 0;
            //Цикл проверки каждого элемента массива
            for (int i = 0; i < Somenumbers.Length; i++)
            {
                // Условия завершения цикла до ошибки
                if (i == Somenumbers.Length - 1)
                {
                    if(test1 == i)
                    {
                        conclusion = 3;
                        break;
                    }
                    //Присваивание результата при полном прохождении цикла (арифметическая прогрессия)
                    conclusion = 1;
                    break;
                }
                test = Somenumbers[i + 1] - Somenumbers[i];
                // Условие завершения цикла т.к. не арифметическая прогрессия
                if (algtest != test) break;
                else if (Somenumbers[i] == Somenumbers[i + 1]) test1++;
                test *= 0;
            }
            test *= 0;
            // Цикл проверки каждого элемента массива
            for (int i = 0; i < Somenumbers.Length; i++)
            {
                if (conclusion == 3) break;
                if (Somenumbers[i] == 0) break;
                int geotest = Somenumbers[1] / Somenumbers[0];
                if (i == Somenumbers.Length - 1)
                {
                    conclusion = 2;
                    break;
                }
                test = Somenumbers[i + 1] / Somenumbers[i];
                if (geotest != test) break;
                test *= 0;
            }
            
            return conclusion;
        }
        static void Main(string[] args)
        {
            int[] test = new int[] {1, 2, 3, 4, 5};
            int[] test1 = new int[] {2, 4, 8, 16, 32};
            int[] test2 = new int[] {2, 3, 10, 1, 2, 3};
            int[] test3 = new int[] { 0, 0, 0, 0, 0, 0 };
            int[] test4 = new int[] { -1, -2, -3, -4, -5 };
            int[] test5 = new int[] { 5, -5, 5, -5, 5, -5 };
            int[] test6 = new int[] {-2, 4, -8, 16, -32 };
            int[] test7 = new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 2 };
            int result = Recognizer(test7);
            if (result == 1) Console.WriteLine("Заданная последовательность чисел является арифметической прогрессией");
            else if (result == 2) Console.WriteLine("Заданная последовательность чисел является геометрической прогрессией");
            else if (result == 0) Console.WriteLine("Заданная последовательность чисел не является арифметической/геометрической прогрессией");
            else if (result == 3) Console.WriteLine("Заданная последовательность чисел может быть как и арифметическая так и геометрическая прогрессия");

            Console.ReadKey();
        }
    }
}
