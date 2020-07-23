using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5._3
{
    class Program
    {
        /// <summary>
        /// Метод удаления всех кратных рядом стоящих символов
        /// </summary>
        /// <param name="TextForSorting">текстовая переменная содержащая текст</param>
        /// <returns></returns>
        static string Sort(string TextForSorting)
        {
            // Массив в котором будет хранится каждая буква в отдельном элементе
            char[] symbols = TextForSorting.ToArray();
            // Цикл присваивания "0" при соблюдении условия
            for (int i = 0; i < symbols.Length; i++)
            {
                // Условие выхода из цикла до ошибки
                if(i == symbols.Length - 1) break;
                //Условие присваивания "0" к элементам с одинаковыми значениями
                if (symbols[i] == symbols[i + 1]) symbols[i] = '0';
            }
            // Цикл подсчета необходимого количества элементов для второго массива
            byte length = 0;
            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i] != '0') length++;
            }
            // Создание второго массива
            char[] symbols1 = new char[length];
            // Цикл присваивание непотворяющихся элементов из первого массива второму
            int j = 0;
            for (int i = 1; i < symbols.Length; i++)
            {
                if (symbols[i] != '0')
                {
                    symbols1[j] = symbols[i];
                    j++;
                }
            }
            // Совмещение всех элементов второго массива и присваивание этого значения переменной "text"
            TextForSorting = String.Concat<char>(symbols1);
            // Возварщение измененной переменной
            return TextForSorting;
        }
        static void Main(string[] args)
        {
            // Проверка работы метода
            string text = "ППППППООООГГГОДДДАА";
            Console.WriteLine($"{text}");
            string sortresult = Sort(text);
            Console.WriteLine($"Результат метода: {sortresult}");

            string text1 = "Ххххоорррроооошшшиииййй деееннннььь";
            Console.WriteLine($"{text1}");
            string sortresult1 = Sort(text1);
            Console.WriteLine($"Результат метода: {sortresult1}");

            Console.ReadKey();
        }
    }
}
