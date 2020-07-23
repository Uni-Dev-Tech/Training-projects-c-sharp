using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanForEveryday1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Проверка метода создания записи и отоброжение ее в консоли
            //Console.WriteLine("Проверка метода создания записи и отоброжение ее в консоли");
            //ExternalRepository creation = new ExternalRepository(0);
            //creation.Add(new Ivent(1, new DateTime(2020, 04, 15), "Sunday", "Work", "Finish the project"));
            //creation.Add(new Ivent(2, new DateTime(2020, 04, 16), "Monday", "School", "Help with homework"));
            //creation.Add(new Ivent(3, new DateTime(2020, 04, 17), "Tuesday", "Sport", "Increse the weight"));
            //creation.Add(new Ivent(4, new DateTime(2020, 04, 18), "Something"));
            //creation.Add(new Ivent(5, "Something"));
            //creation.PrintToConsole();

            //// Проверка метода удаления записи по позиции
            //Console.WriteLine("Проверка метода удаления записи по позиции");
            //creation.DeleteAccordingPosition(3);
            //creation.PrintToConsole();
            //// Возвращаем удаленное
            //creation.Add(new Ivent(3, new DateTime(2020, 08, 20), "Tuesday", "Sport", "Increse the weight"));
            //creation.PrintToConsole();

            //// Проверка метода удаления записи по дате
            //Console.WriteLine("Проверка метода удаления записи по дате");
            //creation.DeleteAccordingDate(new DateTime(2020, 04, 17));
            //creation.PrintToConsole();
            //creation.Add(new Ivent(3, new DateTime(2020, 04, 17), "Tuesday", "Sport", "Increse the weight"));
            //creation.PrintToConsole();

            //// Проверка метода изменения записи по позиции
            //Console.WriteLine("Проверка метода изменения записи по позиции");
            //creation.ChangesAccordingPosition(3, "Decrease the weight");
            //creation.PrintToConsole();

            //// Проверка метода изменения записи по дате
            //Console.WriteLine("Проверка метода изменения записи по дате");
            //creation.ChangesAccordingDate(new DateTime(2020, 04, 17), 4, new DateTime(2020, 04, 17), "Wednesday", "Bar", "Hang out with friends");
            //creation.PrintToConsole();



            //// Проверка метода загрузки данных из файла
            //Console.WriteLine("Проверка метода загрузки данных из файла");
            //ExternalRepository downloadfile = new ExternalRepository(@"DownloadFile.txt");
            //downloadfile.PrintToConsole();

            ////Проверка метода выгрузки данных в файл
            //Console.WriteLine("Проверка метода выгрузки данных в файл");
            //downloadfile.Save(@"DestinationFile.txt");
            //// Проверка данных в файле
            //ExternalRepository DestinationFile = new ExternalRepository(@"DestinationFile.txt");
            //DestinationFile.PrintToConsole();

            //// Проверка метода сортировки данных по позиции
            //Console.WriteLine("Проверка метода сортировки данных по дате");
            //ExternalRepository sortbyposition = new ExternalRepository(@"SortByPosition.txt");
            //sortbyposition.PrintToConsole();
            //sortbyposition.SortByPosition();
            //sortbyposition.PrintToConsole();

            //// Проверка метода сортировки данных по дате
            //Console.WriteLine("Проверка метода сортировки данных по дате");
            //ExternalRepository sortbydate = new ExternalRepository(@"SortByDate.txt");
            //sortbydate.PrintToConsole();
            //sortbydate.SortByDate();
            //sortbydate.PrintToConsole();

            //// Проверка метода импорта записей из файла по выбранному диапазону дат
            //Console.WriteLine("Проверка метода импорта записей из файла по выбранному диапазону дат");
            //ExternalRepository beforeimportdate = new ExternalRepository(@"BeforeImportAccordingDate.txt");
            //Console.WriteLine("Перед методом: ");
            //beforeimportdate.PrintToConsole(); // Перед методом
            //Console.WriteLine("Данные которые импортируем по дате: ");
            //ExternalRepository importdate = new ExternalRepository(@"ImportAccordingDate.txt");
            //importdate.PrintToConsole();
            //beforeimportdate.ImportAccordingDate(@"ImportAccordingDate.txt", new DateTime(2014, 06, 26), new DateTime(2014, 06, 28));
            //Console.WriteLine("Полученные данные: ");
            //beforeimportdate.PrintToConsole();

            //// Проверка метода добавления данных в текущий ежедневник из выбранного файла
            //Console.WriteLine("Проверка метода добавления данных в текущий ежедневник из выбранного файла");
            //ExternalRepository chosenfile = new ExternalRepository(@"ChosenFile(Destination).txt");
            //Console.WriteLine("До метода: ");
            //chosenfile.PrintToConsole();
            //Console.WriteLine("Данные которые собираемся добавить: ");
            //ExternalRepository addtoplan = new ExternalRepository(@"AddToPlan.txt");
            //addtoplan.PrintToConsole();
            //chosenfile.AddDateFromFile(@"AddToPlan.txt");
            //Console.WriteLine("После метода: ");
            //chosenfile.PrintToConsole();

            Console.ReadKey();
        }
    }
}
