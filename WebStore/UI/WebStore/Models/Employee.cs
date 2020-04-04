using System;
using System.ComponentModel;

namespace WebStore.Models
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// EmployeeId
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [DisplayName("Фамилия")]
        public string SurName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [DisplayName("Отчество")]
        public string Patronymic { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        [DisplayName("Возраст")]
        public int Age { get; set; }

        /// <summary>
        /// Подразделение
        /// </summary>
        [DisplayName("Подразделение")]
        public string Department { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        [DisplayName("Адрес электронной почты")]
        public string Email{ get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [DisplayName("Дата рождения")]
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Дата приема на работу
        /// </summary>
        [DisplayName("Дата приема на работу")]
        public DateTime DateOfEmployment { get; set; }

        /// <summary>
        /// Полное ФИО
        /// </summary>
        [DisplayName("Полное ФИО")]
        public string FIO => $"{SurName} {FirstName} {Patronymic}";

    }
}
