using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanForEveryday1._1
{
    struct ExternalRepository
    {

        #region Массивы

        // Основной массив для хранения данных
        private Ivent[] ivents;

        //Путь к файлу с данными
        private string path;

        //Элемент для добавления в массив
        uint index;

        // Массв для хранения заголовков
        string[] titles;

        #endregion

        #region Конуструктор

        /// <summary>
        /// Конструтор
        /// </summary>
        /// <param name="Path">Путь к файлу с папками</param>
        public ExternalRepository(string Path)
        {
            this.path = Path; // Сохранение пути к файлу с данными
            this.index = 0; // позиция для добавления сотрудника в массив
            this.titles = new string[0]; // инициализация массива заголовков
            this.ivents = new Ivent[1]; // инициализакия массива сотрудников

            this.Load(); // Загрузка данных
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="indexnumber">Индекс(0 по-умолчанию)</param>
        public ExternalRepository(uint indexnumber)
        {
            this.path = String.Empty;
            this.index = indexnumber;
            this.titles = new string[5];
            this.ivents = new Ivent[1];

            this.titles[0] = "Position";
            this.titles[1] = "Date";
            this.titles[2] = "Day of the Week";
            this.titles[3] = "Headline";
            this.titles[4] = "Content";
        }

        #endregion

        #region Методы

        /// <summary>
        /// Метод загрузки данных
        /// </summary>
        private void Load()
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                titles = sr.ReadLine().Split(',');
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split(',');
                    // Предотвращает попадание названий полей в список
                    if (args[0] == titles[0] && args[1] == titles[1] && args[2] == titles[2] && args[3] == titles[3] && args[4] == titles[4]) continue;
                    Add(new Ivent(Convert.ToUInt32(args[0]), Convert.ToDateTime(args[1]), args[2], args[3], args[4]));
                }
            }
        }

        /// <summary>
        /// Метод добавления события в хранилище
        /// </summary>
        /// <param name="ConcreteIvent">Событие</param>
        public void Add(Ivent ConcreteIvent)
        {
            this.Resize(index >= this.ivents.Length);
            this.ivents[index] = ConcreteIvent;
            this.index++;
        }

        /// <summary>
        /// Метод увеличения текущего хранилища
        /// </summary>
        /// <param name="Flag">Условие увеличения</param>
        private void Resize(bool Flag)
        {
            if(Flag)
            {
                Array.Resize(ref this.ivents, this.ivents.Length * 2);
            }
        }

        /// <summary>
        /// Метод сохранения данных
        /// </summary>
        /// <param name="Path">Путь к файлу сохранения</param>
        public void Save(string Path)
        {
            string temp = String.Format("{0},{1},{2},{3},{4}",
                                        this.titles[0],
                                        this.titles[1],
                                        this.titles[2],
                                        this.titles[3],
                                        this.titles[4]);
            File.AppendAllText(Path, $"{temp}\n");

            for (int i = 0; i < this.index; i++)
            {
                temp = String.Format("{0},{1},{2},{3},{4}",
                                        this.ivents[i].NumberPosition,
                                        this.ivents[i].Date,
                                        this.ivents[i].DateOfTheWeek,
                                        this.ivents[i].Headline,
                                        this.ivents[i].Content);
                File.AppendAllText(Path, $"{temp}\n");
            }
        }


        /// <summary>
        /// Вывод данных в консоль
        /// </summary>
        public void PrintToConsole()
        {
            Console.WriteLine($"{this.titles[0],10} {this.titles[1],10} {this.titles[2],10} {this.titles[3],10} {this.titles[4],10}");

            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(this.ivents[i].Print());
            }
        }

        /// <summary>
        /// Метод удаления по позиции (удаляет первое в списке)
        /// </summary>
        /// <param name="position">Позиция события</param>
        public void DeleteAccordingPosition(uint position)
        {
            for (int i = 0; i < index; i++)
            {
                if (ivents[i].NumberPosition == position)       // Поиск позиции в списке
                {
                    ivents[i].NumberPosition = 0;               // Удаляет данные 
                    ivents[i].DateOfTheWeek = String.Empty;
                    ivents[i].Headline = String.Empty;
                    ivents[i].Content = String.Empty;
                    for (int j = i; j < index; j++)
                    {
                        ivents[j].NumberPosition = ivents[j + 1].NumberPosition;        // Заполняет образовашийся пробел в списке
                        ivents[j].Date = ivents[j + 1].Date;
                        ivents[j].DateOfTheWeek = ivents[j + 1].DateOfTheWeek;
                        ivents[j].Headline = ivents[j + 1].Headline;
                        ivents[j].Content = ivents[j + 1].Content;
                    }
                    index--;
                }
            }
        }

        /// <summary>
        /// Метод удаления по дате (удаляет первое в списке)
        /// </summary>
        /// <param name="ConcreteDate">Конкретная дата</param>
        public void DeleteAccordingDate(DateTime ConcreteDate)
        {
            for (int i = 0; i < index; i++)
            {
                if (ivents[i].Date == ConcreteDate)         // Поиск по дате в списке
                {
                    ivents[i].NumberPosition = 0;           // Удаляет данные
                    ivents[i].DateOfTheWeek = String.Empty;
                    ivents[i].Headline = String.Empty;
                    ivents[i].Content = String.Empty;
                    for (int j = i; j < index; j++)
                    {
                        ivents[j].NumberPosition = ivents[j + 1].NumberPosition;        // Заполняет образовавшийся пробел в списке
                        ivents[j].Date = ivents[j + 1].Date;
                        ivents[j].DateOfTheWeek = ivents[j + 1].DateOfTheWeek;
                        ivents[j].Headline = ivents[j + 1].Headline;
                        ivents[j].Content = ivents[j + 1].Content;
                    }
                    index--;
                }
            }
        }

        #region Перегрузка метода измения данных по позиции
        /// <summary>
        /// Метод изменения данных по позиции
        /// </summary>
        /// <param name="Position">Нынешняя позиция события</param>
        /// <param name="NewPosition">Новая позиция события</param>
        /// <param name="NewDate">Новая дата события</param>
        /// <param name="NewDateOfTheWeek">Новый день недели события</param>
        /// <param name="NewHeadline">Новый заголовок события</param>
        /// <param name="NewContent">Новое содержание события</param>
        public void ChangesAccordingPosition(uint Position, uint NewPosition, DateTime NewDate, string NewDateOfTheWeek, string NewHeadline, string NewContent)
        {
            for (int i = 0; i < index; i++)
            {
                if (ivents[i].NumberPosition == Position)
                {
                    ivents[i].NumberPosition = NewPosition;
                    ivents[i].Date = NewDate;
                    ivents[i].DateOfTheWeek = NewDateOfTheWeek;
                    ivents[i].Headline = NewHeadline;
                    ivents[i].Content = NewContent;
                }
            }
        }

        /// <summary>
        /// Метод изменения данных по позиции
        /// </summary>
        /// <param name="Position">Нынешняя позиция события</param>
        /// <param name="NewDate">Новая дата события</param>
        /// <param name="NewDateOfTheWeek">Новый день недели события</param>
        /// <param name="NewHeadline">Новый заголовок события</param>
        /// <param name="NewContent">Новое содержание события</param>
        public void ChangesAccordingPosition(uint Position, DateTime NewDate, string NewDateOfTheWeek, string NewHeadline, string NewContent)
        {
            for (int i = 0; i < index; i++)
            {
                if (ivents[i].NumberPosition == Position)
                {
                    ivents[i].Date = NewDate;
                    ivents[i].DateOfTheWeek = NewDateOfTheWeek;
                    ivents[i].Headline = NewHeadline;
                    ivents[i].Content = NewContent;
                }
            }
        }


        /// <summary>
        /// Метод изменения данных по позиции
        /// </summary>
        /// <param name="Position">Нынешняя позиция события</param>
        /// <param name="NewDateOfTheWeek">Новый день недели события</param>
        /// <param name="NewHeadline">Новый заголовок события</param>
        /// <param name="NewContent">Новое содержание события</param>
        public void ChangesAccordingPosition(uint Position, string NewDateOfTheWeek, string NewHeadline, string NewContent)
        {
            for (int i = 0; i < index; i++)
            {
                if (ivents[i].NumberPosition == Position)
                {
                    ivents[i].DateOfTheWeek = NewDateOfTheWeek;
                    ivents[i].Headline = NewHeadline;
                    ivents[i].Content = NewContent;
                }
            }
        }


        /// <summary>
        /// Метод изменения данных по позиции
        /// </summary>
        /// <param name="Position">Нынешняя позиция события</param>
        /// <param name="NewHeadline">Новый заголовок события</param>
        /// <param name="NewContent">Новое содержание события</param>
        public void ChangesAccordingPosition(uint Position, string NewHeadline, string NewContent)
        {
            for (int i = 0; i < index; i++)
            {
                if (ivents[i].NumberPosition == Position)
                {
                    ivents[i].Headline = NewHeadline;
                    ivents[i].Content = NewContent;
                }
            }
        }

        /// <summary>
        /// Метод изменения данных по позиции
        /// </summary>
        /// <param name="Position">Нынешняя позиция события</param>
        /// <param name="NewContent">Новое содержание события</param>
        public void ChangesAccordingPosition(uint Position, string NewContent)
        {
            for (int i = 0; i < index; i++)
            {
                if (ivents[i].NumberPosition == Position)
                {
                    ivents[i].Content = NewContent;
                }
            }
        }
        #endregion

        #region Перегрузка метода изменения данных по дате

        /// <summary>
        /// Метод изменения данных по дате
        /// </summary>
        /// <param name="DateSearch">Нынешняя дата события</param>
        /// <param name="NewPosition">Новая позиция события</param>
        /// <param name="NewDate">Новая дата события</param>
        /// <param name="NewDateOfTheWeek">Новый день недели события</param>
        /// <param name="NewHeadline">Новый заголовок события</param>
        /// <param name="NewContent">Новое содержание события</param>
        public void ChangesAccordingDate(DateTime DateSearch, uint NewPosition, DateTime NewDate, string NewDateOfTheWeek, string NewHeadline, string NewContent)
        {
            for (int i = 0; i < index; i++)
            {
                if (ivents[i].Date == DateSearch)
                {
                    ivents[i].NumberPosition = NewPosition;
                    ivents[i].Date = NewDate;
                    ivents[i].DateOfTheWeek = NewDateOfTheWeek;
                    ivents[i].Headline = NewHeadline;
                    ivents[i].Content = NewContent;
                }
            }
        }

        /// <summary>
        /// Метод изменения данных по дате
        /// </summary>
        /// <param name="DateSearch">Нынешняя дата события</param>
        /// <param name="NewDate">Новая дата события</param>
        /// <param name="NewDateOfTheWeek">Новый день недели события</param>
        /// <param name="NewHeadline">Новый заголовок события</param>
        /// <param name="NewContent">Новое содержание события</param>
        public void ChangesAccordingDate(DateTime DateSearch, DateTime NewDate, string NewDateOfTheWeek, string NewHeadline, string NewContent)
        {
            for (int i = 0; i < index; i++)
            {
                if (ivents[i].Date == DateSearch)
                {
                    ivents[i].Date = NewDate;
                    ivents[i].DateOfTheWeek = NewDateOfTheWeek;
                    ivents[i].Headline = NewHeadline;
                    ivents[i].Content = NewContent;
                }
            }
        }

        /// <summary>
        /// Метод изменения данных по дате
        /// </summary>
        /// <param name="DateSearch">Нынешняя дата события</param>
        /// <param name="NewDateOfTheWeek">Новый день недели события</param>
        /// <param name="NewHeadline">Новый заголовок события</param>
        /// <param name="NewContent">Новое содержание события</param>
        public void ChangesAccordingDate(DateTime DateSearch, string NewDateOfTheWeek, string NewHeadline, string NewContent)
        {
            for (int i = 0; i < index; i++)
            {
                if (ivents[i].Date == DateSearch)
                {
                    ivents[i].DateOfTheWeek = NewDateOfTheWeek;
                    ivents[i].Headline = NewHeadline;
                    ivents[i].Content = NewContent;
                }
            }
        }

        /// <summary>
        /// Метод изменения данных по дате
        /// </summary>
        /// <param name="DateSearch">Нынешняя дата события</param>
        /// <param name="NewHeadline">Новый заголовок события</param>
        /// <param name="NewContent">Новое содержание события</param>
        public void ChangesAccordingDate(DateTime DateSearch, string NewHeadline, string NewContent)
        {
            for (int i = 0; i < index; i++)
            {
                if (ivents[i].Date == DateSearch)
                {
                    ivents[i].Headline = NewHeadline;
                    ivents[i].Content = NewContent;
                }
            }
        }

        /// <summary>
        /// Метод изменения данных по дате
        /// </summary>
        /// <param name="DateSearch">Нынешняя дата события</param>
        /// <param name="NewContent">Новое содержание события</param>
        public void ChangesAccordingDate(DateTime DateSearch, string NewContent)
        {
            for (int i = 0; i < index; i++)
            {
                if (ivents[i].Date == DateSearch)
                {
                    ivents[i].Content = NewContent;
                }
            }
        }


        #endregion

        #region Методы сортировки данных по позиции и дате

        /// <summary>
        /// Метод сортировки данных по позиции (в правильном, последовательном порядке)
        /// </summary>
        public void SortByPosition()
        {
            for (int j = 0; j < index; j++)
            {
                for (int i = 0; i < index; i++)
                {
                    if (ivents[i].NumberPosition > ivents[i + 1].NumberPosition)        // Сравниваем позиции рядом стоящих записей
                    {
                        ivents[index + 1].NumberPosition = ivents[i + 1].NumberPosition;  // Сохраняем данные под неиспользуемым индексом второй записи
                        ivents[index + 1].Date = ivents[i + 1].Date;
                        ivents[index + 1].DateOfTheWeek = ivents[i + 1].DateOfTheWeek;
                        ivents[index + 1].Headline = ivents[i + 1].Headline;
                        ivents[index + 1].Content = ivents[i + 1].Content;

                        ivents[i + 1].NumberPosition = ivents[i].NumberPosition;           // Перемещаем данные из первой записи во вторую
                        ivents[i + 1].Date = ivents[i].Date;
                        ivents[i + 1].DateOfTheWeek = ivents[i].DateOfTheWeek;
                        ivents[i + 1].Headline = ivents[i].Headline;
                        ivents[i + 1].Content = ivents[i].Content;

                        ivents[i].NumberPosition = ivents[index + 1].NumberPosition;        // Перемещаем данные второй записи в первую
                        ivents[i].Date = ivents[index + 1].Date;
                        ivents[i].DateOfTheWeek = ivents[index + 1].DateOfTheWeek;
                        ivents[i].Headline = ivents[index + 1].Headline;
                        ivents[i].Content = ivents[index + 1].Content;
                    }
                }
            }
            for (int i = 0; i < index; i++) // "Костыль" поправляющий список
            {
                ivents[i].NumberPosition = ivents[i + 1].NumberPosition;
                ivents[i].Date = ivents[i + 1].Date;
                ivents[i].DateOfTheWeek = ivents[i + 1].DateOfTheWeek;
                ivents[i].Headline = ivents[i + 1].Headline;
                ivents[i].Content = ivents[i + 1].Content;
            }
        }

        /// <summary>
        /// Метод сортировки данных по дате
        /// </summary>
        public void SortByDate()
        {
            for (int j = 0; j < index; j++)
            {
                for (int i = 0; i < index; i++)
                {
                    if (ivents[i].Date > ivents[i + 1].Date)
                    {
                        ivents[index + 1].NumberPosition = ivents[i + 1].NumberPosition;
                        ivents[index + 1].Date = ivents[i + 1].Date;
                        ivents[index + 1].DateOfTheWeek = ivents[i + 1].DateOfTheWeek;
                        ivents[index + 1].Headline = ivents[i + 1].Headline;
                        ivents[index + 1].Content = ivents[i + 1].Content;

                        ivents[i + 1].NumberPosition = ivents[i].NumberPosition;
                        ivents[i + 1].Date = ivents[i].Date;
                        ivents[i + 1].DateOfTheWeek = ivents[i].DateOfTheWeek;
                        ivents[i + 1].Headline = ivents[i].Headline;
                        ivents[i + 1].Content = ivents[i].Content;

                        ivents[i].NumberPosition = ivents[index + 1].NumberPosition;
                        ivents[i].Date = ivents[index + 1].Date;
                        ivents[i].DateOfTheWeek = ivents[index + 1].DateOfTheWeek;
                        ivents[i].Headline = ivents[index + 1].Headline;
                        ivents[i].Content = ivents[index + 1].Content;
                    }
                }
            }
            for (int i = 0; i < index; i++)
            {
                ivents[i].NumberPosition = ivents[i + 1].NumberPosition;
                ivents[i].Date = ivents[i + 1].Date;
                ivents[i].DateOfTheWeek = ivents[i + 1].DateOfTheWeek;
                ivents[i].Headline = ivents[i + 1].Headline;
                ivents[i].Content = ivents[i + 1].Content;
            }
        }

        #endregion

        /// <summary>
        /// Метод импорта записей из файла по выбранному диапазону дат
        /// </summary>
        /// <param name="Path">Название файла</param>
        /// <param name="FromDate">С этой даты(включитедьно)</param>
        /// <param name="UntilDate">По эту дату(не включительно)</param>
        public void ImportAccordingDate(string PathToFile, DateTime FromDate, DateTime UntilDate)
        {
            ExternalRepository path = new ExternalRepository(PathToFile);
            for (int i = 0; i < path.ivents.Length; i++)
            {
                if(path.ivents[i].Date >= FromDate && path.ivents[i].Date <= UntilDate)
                {
                    Add(new Ivent(path.ivents[i].NumberPosition, path.ivents[i].Date, path.ivents[i].DateOfTheWeek, path.ivents[i].Headline, path.ivents[i].Content));
                }
            }
        }

        /// <summary>
        /// Метод добавления данных в текущий ежедневник из выбранного файла
        /// </summary>
        /// <param name="PathToFile">Название файла</param>
        public void AddDateFromFile(string PathToFile)
        {
            ExternalRepository pathtofile = new ExternalRepository(PathToFile);
            for (int i = 0; i < pathtofile.ivents.Length; i++)
            {
                Add(new Ivent(pathtofile.ivents[i].NumberPosition, pathtofile.ivents[i].Date, pathtofile.ivents[i].DateOfTheWeek, pathtofile.ivents[i].Headline, pathtofile.ivents[i].Content));
            }
        }

        #endregion

        #region Свойство

        /// <summary>
        /// Количество сотрудников в хранилище
        /// </summary>
        public uint Count { get { return this.index; } }

        #endregion

    }
}
