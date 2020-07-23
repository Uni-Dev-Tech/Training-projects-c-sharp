using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5._5
{
    class Program
    {
        /// <summary>
        /// Метод вычисления функции Аккермана использующий рекурсию
        /// </summary>
        /// <param name="N">первое число</param>
        /// <param name="M">второе число</param>
        /// <returns></returns>
        static int Akkerman (int N, int M)
        {
            if (N == 0)
                return M + 1;
            else if (N != 0 && M == 0)
                return Akkerman(N - 1, 1);
            else
                return Akkerman(N-1, Akkerman(N, M - 1));
        }
        static void Main(string[] args)
        {
            //Проверка метода
            Console.WriteLine($"{Akkerman(2, 5)}");
            Console.WriteLine($"{Akkerman(1, 2)}");
            Console.ReadKey();
        }
    }
}
