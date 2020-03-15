using System;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Attributes.Validation
{
    /// <summary>
    /// Проверка валидности даты для указанного диапазона
    /// </summary>
    public class DateRangeAttribute : ValidationAttribute
    {

        /// <summary>
        /// Минимальная допустимая дата
        /// </summary>
        public DateTime MinDate { get; private set; } = new DateTime(1970, 1, 1);

        /// <summary>
        /// Максимальная доспустимая дата
        /// </summary>
        public DateTime MaxDate { get; private set; } = DateTime.Now;


        /// <summary>
        /// Добавление атрибута проверки корректности даты для указанного диапазона
        /// </summary>
        /// <param name="minDate">Минимальная дата в формате yyyy.mm.dd</param>
        /// <param name="maxDate">Максимальная дата дата в формате yyyy.mm.dd</param>
        /// <param name="errorMessage"></param>
        public DateRangeAttribute(string minDate, string maxDate)
        {
            if (DateTime.TryParse(minDate, out DateTime _minDate))
                MinDate = _minDate;

            if (DateTime.TryParse(maxDate, out DateTime _maxDate))
                MaxDate = _maxDate;
        }

        /// <summary>
        /// Добавление атрибута проверки корректности даты от минимального значения до текущего дня
        /// </summary>
        /// <param name="minDate">Минимальная дата в формате yyyy.mm.dd</param>
        /// <param name="errorMessage"></param>
        public DateRangeAttribute(string minDate): //, string errorMessage = null) :
            this(minDate, "")
        {
        }

        /// <summary>
        /// Проверка
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            DateTime dateToValidate;
            bool tryParse = DateTime.TryParse(value.ToString(), out dateToValidate);
            return tryParse && dateToValidate > MinDate && dateToValidate < MaxDate;
        }

        /// <summary>
        /// Вывод сообщения об ошибке
        /// </summary>
        /// <param name="name">Имя параметра</param>
        /// <returns></returns>
        public override string FormatErrorMessage(string name)
        {
            return $"В указанном поле [{name}] введена не правильная дата , введите дату в диапозоне {MinDate} - {MaxDate}";
        }
    }
}
