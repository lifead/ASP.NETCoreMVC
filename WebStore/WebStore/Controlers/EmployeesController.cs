using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.Services;

namespace WebStore.Controlers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index() => View(VirtualDB.GetEmployees());

        public IActionResult Details(int employeeId)
        {
            EmployeeView employee = VirtualDB.GetEmployee(employeeId);
            return View(employee);
        }

    }
}