using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebStore.Models;
using WebStore.Services;

namespace WebStore.Controlers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Employees() => View(VirtualDB.GetEmployees());

        public IActionResult Details(int employeeId)
        {
            EmployeeView employee = VirtualDB.GetEmployee(employeeId);
            return View(employee);
        }

        public IActionResult SomeAction() => View();



        public IActionResult Error404() => View();
        public IActionResult Blog() => View();
        public IActionResult BlogSingle() => View();
        public IActionResult Cart() => View();
        public IActionResult CheckOut() => View();
        public IActionResult ContactUs() => View();
        public IActionResult Login() => View();
        public IActionResult Shop() => View();
        public IActionResult ProductDetails() => View();

    }
}