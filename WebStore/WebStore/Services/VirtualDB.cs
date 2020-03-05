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
        /*
        Дополнительная информация может быть любой, дополняющей основную: дату рождения, возраст, дата устройства на работу и т.д.         *
        */


        /// <summary>
        /// Получить всех сотрудников
        /// </summary>
        /// <returns></returns>
        static public List<EmployeeView> GetEmployees()
        {
            return employees;
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


    }
}
