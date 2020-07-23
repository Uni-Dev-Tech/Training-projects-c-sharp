using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5._1
{
    class Program
    {
        /// <summary>
        /// Метод умножения матриц на число
        /// </summary>
        /// <param name="Number">число</param>
        /// <param name="Matrix">матрица</param>
        static int[,] NumberMatrix(int Number, int[,] Matrix)
        {
            int[,] matrixresult = new int[Matrix.GetLength(0), Matrix.GetLength(1)];
            int content = 0;
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    content = Matrix[i, j] * Number;
                    matrixresult[i, j] += content;
                }
            }
            return matrixresult;
        }
        /// <summary>
        /// Метод суммирования матриц
        /// </summary>
        /// <param name="Mat">первая матрица</param>
        /// <param name="Matr">вторая матрица</param>
        static int[,] MatrixPlusMatrix(int[,] Mat, int[,] Matr)
        {
            int[,] matrixresult = new int[Mat.GetLength(0), Mat.GetLength(1)];
            int content = 0;
            for (int i = 0; i < Mat.GetLength(0); i++)
            {
                for (int j = 0; j < Mat.GetLength(1); j++)
                {
                    content = Mat[i, j] + Matr[i, j];
                    matrixresult[i, j] += content;
                }
            }
            return matrixresult;
        }
        /// <summary>
        /// Метод умножения двух матриц
        /// </summary>
        /// <param name="Mat">первая матрица</param>
        /// <param name="Matr">вторая матрица</param>
        static int[,] MatrixVsMatrix(int[,] Mat, int[,] Matr)
        {
            int[,] matrixresult = new int[Mat.GetLength(0), Matr.GetLength(1)];
            int content = 0;
            for (int i = 0; i < Mat.GetLength(0); i++)
            {
                for (int j = 0; j < Matr.GetLength(1); j++)
                {
                    for (int a = 0; a < Mat.GetLength(0); a++)
                    {
                        content = Mat[i, a] * Matr[a, j];
                        matrixresult[i, j] += content;
                    }
                }
            }
            return matrixresult;
        }
        /// <summary>
        /// Метод выводящий массив (матрицу) в консоль
        /// </summary>
        /// <param name="Mat">матрица, которую необходимо вывести в консоль</param>
        static void Show(int[,] Mat)
        {
            for (int i = 0; i < Mat.GetLength(0); i++)
            {
                for (int j = 0; j < Mat.GetLength(1); j++)
                {
                    Console.Write($" {Mat[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Метод заполения матрицы (массива)
        /// </summary>
        /// <param name="Matrix">Матрица (массив)</param>
        /// <returns></returns>
        static int[,] MatrixFilling(int[,] Matrix)
        {
            Random randomize = new Random();
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Matrix[i, j] = randomize.Next(10);
                }
            }
            return Matrix;
        }
        static void Main(string[] args)
        {
            // Пример работы метода умножения матрицы на число
            // Создание массива и его заполнение
            int[,] matrix1 = new int[5, 5];
            MatrixFilling(matrix1);
            Console.WriteLine("Сгенерированная матрица");
            Show(matrix1);

            // Применения метода умножения на число
            Console.WriteLine("Результат умножения на число");
            int[,] matrixresult1 = NumberMatrix(5, matrix1);
            Show(matrixresult1);

            // Пример работы метода умножения матрицы на матрицу
            // Создание массива и его заполнение
            Console.WriteLine();
            int[,] matrix2 = new int[2, 3];
            MatrixFilling(matrix2);
            Console.WriteLine("Сгенерированная матрица");
            Show(matrix2);

            // Создание массива и его заполнение
            Console.WriteLine();
            int[,] matrix3 = new int[3, 2];
            MatrixFilling(matrix3);
            Console.WriteLine("Сгенерированная матрица");
            Show(matrix3);

            // Применение метода умножения матриц 
            Console.WriteLine("Результат умножения матрицы на матрицу");
            int[,] matrixresult2 = MatrixVsMatrix(matrix2, matrix3);
            Show(matrixresult2);

            // Пример работы метода суммирования матриц
            // Создание двум массивов и их последующее заполнение
            Console.WriteLine("Первая матрица");
            int[,] matrix4 = new int[3, 3];
            MatrixFilling(matrix4);
            Show(matrix4);
            Console.WriteLine("Вторая матрица");
            int[,] matrix5 = new int[3, 3];
            MatrixFilling(matrix5);
            Show(matrix5);
            // Применение метода суммирования матриц
            Console.WriteLine("Результат суммы матриц");
            int[,] matrixresult3 = MatrixPlusMatrix(matrix4, matrix5);
            Show(matrixresult3);


            Console.ReadKey();
        }
    }
}
