using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Models;

namespace WebStore.Services
{

    public class VirtualDB
    {
        private static readonly List<EmployeeView> employees = new List<EmployeeView>();

        static VirtualDB()
        {
            employees.AddRange(new[] {
                 new EmployeeView(){ EmployeeId = 1, Age = 23, Department="Отдел № 1", Email="ges@example.com", SurName = "Гусев", FirstName = "Ефрем", Patronymic = "Степановна"       ,BirthDay = new DateTime(2000,01,21), DateOfEmployment = new DateTime(2020,03,01)}
                ,new EmployeeView(){ EmployeeId = 2, Age = 34, Department="Отдел № 1", Email="akp@example.com", SurName = "Акимова ", FirstName = "Кристина ", Patronymic = "Петрович"  ,BirthDay = new DateTime(2000,04,14), DateOfEmployment = new DateTime(2020,03,02)}
                ,new EmployeeView(){ EmployeeId = 3, Age = 45, Department="Отдел № 2", Email="jvd@example.com", SurName = "Жгулёв", FirstName = "Владилен", Patronymic = "Дмитриевич"   ,BirthDay = new DateTime(2000,02,27), DateOfEmployment = new DateTime(2020,02,04)}
                ,new EmployeeView(){ EmployeeId = 4, Age = 32, Department="Отдел № 3", Email="snf@example.com", SurName = "Сонина ", FirstName = "Надежда", Patronymic = "Феликсовна"   ,BirthDay = new DateTime(2000,05,05), DateOfEmployment = new DateTime(2020,02,09)}
            });
        }


        /// <summary>
        /// Получить всех сотрудников
        /// </summary>
        /// <returns></returns>
        static public List<EmployeeView> GetEmployees()
        {
            return employees;
        }


        /// <summary>
        /// Удаление сотрудника из базы данных по Id
        /// </summary>
        /// <param name="employeeId"></param>
        internal static void Delete(int employeeId)
        {
            var _empl = employees.FirstOrDefault(x => x.EmployeeId == employeeId);
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
        static public EmployeeView GetEmployee(int employeeId)
        {
            var result = employees.FirstOrDefault(x => x.EmployeeId == employeeId);
            return result;
        }


        /// <summary>
        /// Обновление данных о сотруднике
        /// </summary>
        /// <param name="employee"></param>
        static public void Update(EmployeeView employee)
        {
            if (employee == null)
                return;
            else if (employee.EmployeeId == 0)
            {
                int index = employees.Max(x => x.EmployeeId);
                employee.EmployeeId = ++index;
                employees.Add(employee);
            }
            else
            {
                var _empl = employees.FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);
                if (_empl is null)
                    employees.Add(employee);
                else
                {
                    int index = employees.IndexOf(_empl);
                    employees[index] = employee;
                }
            }
        }

    }
}
