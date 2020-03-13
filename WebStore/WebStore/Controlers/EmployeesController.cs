﻿using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.Services;
using WebStore.ViewModels;

namespace WebStore.Controlers
{
    public class EmployeesController : Controller
    {
        /// <summary>
        /// Отображение списка сотрудников
        /// </summary>
        /// <returns></returns>
        public IActionResult Index() => View(VirtualDB.GetEmployees());


        /// <summary>
        /// Отображение карточки сотрудников
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public IActionResult Details(int employeeId)
        {
            EmployeeViewModel employee = VirtualDB.GetEmployee(employeeId);
            return View(employee);
        }


        /// <summary>
        /// Добавление и редактирование информации о сотруднике
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Input(int employeeId)
        {
            EmployeeViewModel employee;

            if (employeeId != 0)
                employee = VirtualDB.GetEmployee(employeeId);
            else
                employee = new EmployeeViewModel();

            return View(employee);
        }

        /// <summary>
        /// Сохранение данных в базу данных
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Input(EmployeeViewModel employee)
        {
            if (employee == null)
                employee = new EmployeeViewModel();
            else
            {
                VirtualDB.Update(employee);
            }

            return View(employee);
        }


        /// <summary>
        /// Удаление данных
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public IActionResult Delete(int employeeId)
        {

            VirtualDB.Delete(employeeId);
            return View("Index", VirtualDB.GetEmployees());
        }
    }
}