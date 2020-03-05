using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebStore.Models;
using WebStore.Services;

namespace WebStore.Controlers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<EmployeeView> employees = VirtualDB.GetEmployees();
            return View(employees);
        }

        public IActionResult Details(int employeeId)
        {
            EmployeeView employee = VirtualDB.GetEmployee(employeeId);
            return View(employee);
        }
    }
}