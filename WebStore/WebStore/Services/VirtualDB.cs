using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Data;
using WebStore.Models;
using WebStore.ViewModels;
using WebStore.Services.Mappers;

namespace WebStore.Services
{

    public class VirtualDB
    {
        private static readonly List<Employee> employees = TestData.Employees;


        /// <summary>
        /// Получить всех сотрудников
        /// </summary>
        /// <returns></returns>
        static public List<EmployeeViewModel> GetEmployees()
        {
            return employees.Select(x=>x.ToViewModel()).ToList();
        }


        /// <summary>
        /// Удаление сотрудника из базы данных по Id
        /// </summary>
        /// <param name="employeeId"></param>
        internal static void Delete(int employeeId)
        {
            var _empl = employees.FirstOrDefault(x => x.Id == employeeId);
            if (_empl != null)
            {
                employees.Remove(_empl);
            }
        }


        /// <summary>
        /// Получить одного сотрудника по employeeId
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        static public EmployeeViewModel GetEmployee(int employeeId)
        {
            var result = employees.FirstOrDefault(x => x.Id == employeeId).ToViewModel();
            return result;
        }


        /// <summary>
        /// Обновление данных о сотруднике
        /// </summary>
        /// <param name="_employee"></param>
        static public void Update(EmployeeViewModel employee)
        {

            if (employee == null)
                return;

            var _employee = employee.ToDataModel();

            if (_employee.Id == 0)
            {
                int index = employees.Max(x => x.Id);
                _employee.Id = ++index;
                employees.Add(_employee);
            }
            else
            {
                var _empl = employees.FirstOrDefault(x => x.Id == _employee.Id);
                if (_empl is null)
                    employees.Add(_employee);
                else
                {
                    int index = employees.IndexOf(_empl);
                    employees[index] = _employee;
                }
            }
        }

    }
}
