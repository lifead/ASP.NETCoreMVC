using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebStore.Domain.Attributes.Validation;

namespace WebStore.Domain.ViewModels.Product
{
    public class EmployeeViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }


        /// <summary>
        /// Имя
        /// </summary>
        [Display(Name = "Имя")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя является обязательным")]
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "Длина строки от 3 до 200 символов")]
        [MinLength(3, ErrorMessage = "Минимальная длина 3 символа")]
        //[RegularExpression(@"(?:[А-ЯЁ][а-яё]+)|(?:[A-Z][a-z]+)", ErrorMessage = "Ошибка формата имени - либо кириллица либо латиница")]
        [DisplayName("Имя")]
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Display(Name = "Фамилия")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия является обязательным")]
        [MinLength(3, ErrorMessage = "Минимальная длина 3 символа")]
        [DisplayName("Фамилия")]
        public string SecondName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [DisplayName("Отчество")]
        public string Patronymic { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        [DisplayName("Возраст")]
        [Range(18, 150, ErrorMessage = "Введите корректное значение возраста")]
        public int Age { get; set; }

        /// <summary>
        /// Подразделение
        /// </summary>
        [DisplayName("Подразделение")]
        [MinLength(2, ErrorMessage = "Название подразденения не может быть менее 2х символов")]
        public string Department { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        [EmailAddress(ErrorMessage = "Введите корректный e-mail адрес")]
        [DisplayName("Адрес электронной почты")]
        public string Email { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [DisplayName("Дата рождения")]
        [DateRange("1850.01.01", ErrorMessage = "Введено некоректное значение даты рождения")]
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Дата приема на работу
        /// </summary>
        [DisplayName("Дата приема на работу")]
        [DateRange("1900.01.01", ErrorMessage = "Введено некоректное значение даты приема на работу")]
        public DateTime DateOfEmployment { get; set; }


        /// <summary>Полное ФИО</summary>
        public override string ToString()
        {
            return $"{SecondName} {Name} {Patronymic}";
        }
    }
}
