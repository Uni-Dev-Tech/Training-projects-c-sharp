using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanForEveryday1._1
{
    struct Ivent
    {

        #region Поля

        /// <summary>
        /// Позиция события
        /// </summary>
        private uint numberposition;

        /// <summary>
        /// Дата события
        /// </summary>
        private DateTime date;

        /// <summary>
        /// День недели
        /// </summary>
        private string dateoftheweek;

        /// <summary>
        /// Заголовок(тема)
        /// </summary>
        private string headline;

        /// <summary>
        /// Описание события
        /// </summary>
        private string content;

        #endregion

        #region Свойства
        /// <summary>
        /// Свойства для позиции события
        /// </summary>
        public uint NumberPosition 
        { 
          get { return this.numberposition; }
          set { this.numberposition = value; }
        }
        /// <summary>
        /// Свойства для даты
        /// </summary>
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }
        /// <summary>
        /// Свойства для дня недели
        /// </summary>
        public string DateOfTheWeek
        {
            get { return this.dateoftheweek; }
            set { this.dateoftheweek = value; }
        }
        /// <summary>
        /// Свойства для заголовка
        /// </summary>
        public string Headline
        {
            get { return this.headline; }
            set { this.headline = value; }
        }
        /// <summary>
        /// Свойства для описания события
        /// </summary>
        public string Content
        {
            get { return this.content; }
            set { this.content = value; }
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор события
        /// </summary>
        /// <param name="NumberPosition">Позиция события</param>
        /// <param name="Date">Дата события</param>
        /// <param name="DateOfTheWeek">День недели</param>
        /// <param name="Headline">Заголовок(тема)</param>
        /// <param name="Content">Описание события</param>
        public Ivent(uint NumberPosition, DateTime Date, string DateOfTheWeek, string Headline, string Content)
        {
            this.numberposition = NumberPosition;
            this.date = Date;
            this.dateoftheweek = DateOfTheWeek;
            this.headline = Headline;
            this.content = Content;
        }

        /// <summary>
        /// Конструктор события
        /// </summary>
        /// <param name="NumberPosition">Позиция события</param>
        /// <param name="Date">Дата события</param>
        /// <param name="Headline">Заголовок(тема)</param>
        /// <param name="Content">Описание события</param>
        public Ivent(uint NumberPosition, DateTime Date, string Headline, string Content) :
            this(NumberPosition, Date, String.Empty, Headline, Content)
        {

        }

        /// <summary>
        /// Конструктор события
        /// </summary>
        /// <param name="NumberPosition">Позиция события</param>
        /// <param name="Date">Дата события</param>
        /// <param name="Content">Описание события</param>
        public Ivent(uint NumberPosition, DateTime Date, string Content) :
            this(NumberPosition, Date, String.Empty, String.Empty, Content)
        {

        }

        /// <summary>
        /// Конструктор события
        /// </summary>
        /// <param name="NumberPosition">Позиция события</param>
        /// <param name="Content">Описание события</param>
        public Ivent(uint NumberPosition, string Content) :
            this(NumberPosition, new DateTime(0001,01,01), String.Empty, String.Empty, Content)
        {

        }

        /// <summary>
        /// Конструктор события
        /// </summary>
        /// <param name="Date"></param>
        /// <param name="Content">Описание события</param>
        public Ivent(DateTime Date, string Content) :
            this(0, Date, String.Empty, String.Empty, Content)
        {

        }

        #endregion

        #region Методы

        public string Print()
        {
            return $"{this.numberposition,5} {this.date,10} {this.dateoftheweek,10} {this.headline,10} {this.content,15}";
        }

        #endregion

    }
}
