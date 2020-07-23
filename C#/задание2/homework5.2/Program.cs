using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5._2
{
    class Program
    {
        /// <summary>
        /// Метод принимающий текст и возвращающий первое слово в списке с минимальным количеством букв
        /// </summary>
        /// <param name="TextForSorting">текстовая переменная содержащая текст</param>
        /// <param name="TextSymbols">символы разделители</param>
        /// <returns></returns>
        static string Smallest(string TextForSorting, char[] TextSymbols)
        {
            // Убирает символы и заполняет массив словами которые были между символами
            string[] mass = TextForSorting.Split(TextSymbols);
            // Создает переменную принимающую размерность первого элемента массива
            int count = mass[0].Length;
            // Создает массив в элементах которого будут хранится размерности элементов предыдущего массива под такими же индексом
            int[] mass1 = new int[mass.Length];
            mass1[0] = count;
            // Цикл передающий размерность каждого элемента первого массива в элементы второго массива под тем же индексом
            for (int i = 1; i < mass.Length; i++)
            {
                mass1[i] = mass[i].Length;
                // Условие нахождение меньшей размерности среди элементов первого массива и присваивание этого значения к переменной "count"
                if (mass[i].Length < count)
                {
                    count *= 0;
                    count += mass[i].Length;
                }
            }
            // Нахождение индекса с значением переменной "count"
            int result = Array.IndexOf(mass1, count);
            // Присваивание переменной "text" слова с наименьшим количеством букв
            TextForSorting = mass[result];
            // Возврат переменной с новым значением
            return TextForSorting;
        }
        /// <summary>
        /// Метод принимающий текст и возвращающий слово(слова) с максимальным количеством букв
        /// </summary>
        /// <param name="TextForSorting">текстовая переменная содержащая текст</param>
        /// <param name="TextSymbols">символы разделители</param>
        /// <returns></returns>
        static string Biggest(string TextForSorting, char[] TextSymbols)
        {
            // Убирает символы и заполняет массив словами которые были между символами
            string[] mass = TextForSorting.Split(TextSymbols);
            // Создает переменную принимающую размерность первого элемента массива
            int count = mass[0].Length;
            // Создает массив в элементах которого будут хранится размерности элементов предыдущего массива под такими же индексом
            int[] mass1 = new int[mass.Length];
            mass1[0] = count;
            // Цикл передающий размерность каждого элемента первого массива в элементы второго массива под тем же индексом
            for (int i = 1; i < mass.Length; i++)
            {
                mass1[i] = mass[i].Length;
                // Условие нахождение большей размерности среди элементов первого массива и присваивание этого значения к переменной "count"
                if (mass[i].Length > count)
                {
                    count *= 0;
                    count += mass[i].Length;
                }
            }
            // Цикл подсчитывающий необходимое количество элементов в третьем массиве
            byte length = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass1[i] == count) length++;
            }
            // Создание третьего массива
            string[] mass2 = new string[length];
            // Цикл присваивание третьему массиву слов с наибольшим количеством букв
            byte j = 0;
            for (int i = 0; i < mass1.Length; i++)
            {
                if (mass1[i] == count)
                {
                    mass2[j] = mass[i];
                    j++;
                }
            }
            // Совмещение всех элементов третьего массива в переменную "text" с разделительным знаком между словами
            TextForSorting = String.Join(", ", mass2);
            //Возвращение измененной переменной
            return TextForSorting;
        }
        static void Main(string[] args)
        {
            // Проверка метода возвращающего слово(слова) с максимальным количеством букв
            string text = "jgfjkfdh fdgkljld!fgyuwegyfewg.fgj,fggfi fgyuwegyfewg/dfsgfgfh dgfjgshjds fgd?ehg";
            char[] textsymbols = new char[] { ',', '.', '-', '!', ' ', '/', '?' };
            string textresult = Biggest(text, textsymbols);
            Console.WriteLine($"Результат метода возвращающего слово(слова) с максимальным количеством букв");
            Console.WriteLine($"Ответ: {textresult}");
            // Проверка метода возвращающего первое слово в списке с минимальным количеством букв
            string text1 = "jgfjkfdh fdgkljld!fkgjdfhg.fgj,fggfi fgyuwegyfewg/dfsgfgfh dgfjgshjds fgd?ehg";
            string textresult1 = Smallest(text1, textsymbols);
            Console.WriteLine($"Результат метода возвращающего слово с минимальным количеством букв");
            Console.WriteLine($"Ответ: {textresult1}");


            Console.ReadKey();
        }
    }
}
