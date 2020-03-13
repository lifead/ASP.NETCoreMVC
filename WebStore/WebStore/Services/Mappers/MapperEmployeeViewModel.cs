using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Services.Mappers
{
    public static class MapperEmployeeViewModel
    {
        #region Mapping to ViewModel (to EmployeeViewModel)
        /// <summary>
        /// Mapping to ViewModel (to EmployeeViewModel)
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static EmployeeViewModel ToViewModel(this Employee employee)
        {
            if (employee is null)
                return null;

            EmployeeViewModel viewModel = new EmployeeViewModel()
            {
                Age = employee.Age,
                BirthDay = employee.BirthDay,
                DateOfEmployment = employee.DateOfEmployment,
                Department = employee.Department,
                Email = employee.Email,
                Name = employee.FirstName,
                Id = employee.Id,
                Patronymic = employee.Patronymic,
                SecondName = employee.SurName
            };
            return viewModel;
        }
        #endregion

        #region Mapping to ToDataModel (to Employee)
        /// <summary>
        /// Mapping to ToDataModel (to Employee)
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static Employee ToDataModel(this EmployeeViewModel employee)
        {
            if (employee is null)
                return null;

            Employee viewModel = new Employee()
            {
                Age = employee.Age,
                BirthDay = employee.BirthDay,
                DateOfEmployment = employee.DateOfEmployment,
                Department = employee.Department,
                Email = employee.Email,
                FirstName = employee.Name,
                Id = employee.Id,
                Patronymic = employee.Patronymic,
                SurName = employee.SecondName
            };
            return viewModel;
        }
        #endregion    
    }
}
