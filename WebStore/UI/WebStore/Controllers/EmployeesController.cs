using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebStore;
using WebStore.Controllers;
using WebStore.Domain.Entities.Identity;
using WebStore.Domain.Models;
using WebStore.Domain.ViewModels.Product;
using WebStore.Interfaces.Services;
using WebStore.Services;



namespace WebStore.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        /// <summary>
        /// Объект с данными
        /// </summary>
        private readonly IEmployeesData _employeesData;


        public EmployeesController(IEmployeesData employeesData) => _employeesData = employeesData;

        /// <summary>
        /// Отображение списка сотрудников
        /// </summary>
        /// <returns></returns>
        public IActionResult Index() => View(_employeesData.GetAll().Select(e => new EmployeeViewModel
        {
            Id = e.Id,
            Name = e.FirstName,
            SecondName = e.SurName,
            Patronymic = e.Patronymic,
            Age = e.Age
        }));


        /// <summary>
        /// Отображение карточки сотрудников
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public IActionResult Details(int Id)
        {
            var employee = _employeesData.GetById(Id);
            if (employee is null)
                return NotFound();

            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.FirstName,
                SecondName = employee.SurName,
                Patronymic = employee.Patronymic,
                Age = employee.Age
            });
        }


        /// <summary>
        /// Добавление и редактирование информации о сотруднике
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult Input(int? id)
        {
            if (id is null) return View(new EmployeeViewModel());

            if (id < 0)
                return BadRequest();

            var employee = _employeesData.GetById((int)id);
            if (employee is null)
                return NotFound();

            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.FirstName,
                SecondName = employee.SurName,
                Patronymic = employee.Patronymic,
                Age = employee.Age
            });
        }

        /// <summary>
        /// Сохранение данных в базу данных
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [Authorize(Roles = Role.Administrator)]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Input(EmployeeViewModel employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));

            if (employee.Name == "123" && employee.SecondName == "QWE")
                ModelState.AddModelError(string.Empty, "Странные имя и фамилия...");

            if (!ModelState.IsValid)
                return View(employee);

            var id = employee.Id;
            if (id == 0)
                _employeesData.Add(new Employee
                {
                    FirstName = employee.Name,
                    SurName = employee.SecondName,
                    Patronymic = employee.Patronymic,
                    Age = employee.Age
                });
            else
                _employeesData.Edit(id, new Employee
                {
                    FirstName = employee.Name,
                    SurName = employee.SecondName,
                    Patronymic = employee.Patronymic,
                    Age = employee.Age
                });

            _employeesData.SaveChanges();

            return RedirectToAction("Index");
        }


        /// <summary>
        /// Create - Добавление пользователя с помощью метода Create
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = Role.Administrator)]
        public IActionResult Create()
        {
            return View(new EmployeeViewModel());
        }

        /// <summary>
        /// Create - Сохранение в БД
        /// </summary>
        /// <param name="Employee"></param>
        /// <returns></returns>
        [Authorize(Roles = Role.Administrator)]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel Employee)
        {
            if (Employee is null)
                throw new ArgumentNullException(nameof(Employee));

            if (!ModelState.IsValid)
                return View(Employee);

            _employeesData.Add(new Employee
            {
                FirstName = Employee.Name,
                SurName = Employee.SecondName,
                Patronymic = Employee.Patronymic,
                Age = Employee.Age
            });
            _employeesData.SaveChanges();

            return RedirectToAction("Index");
        }


        /// <summary>
        /// Удаление данных
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [Authorize(Roles = Role.Administrator)]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var employee = _employeesData.GetById(id);
            if (employee is null)
                return NotFound();

            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.FirstName,
                SecondName = employee.SurName,
                Patronymic = employee.Patronymic,
                Age = employee.Age
            });
        }

        /// <summary>
        /// Удаление после подтверждения
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult DeleteConfirmed(int id)
        {
            _employeesData.Delete(id);
            _employeesData.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}