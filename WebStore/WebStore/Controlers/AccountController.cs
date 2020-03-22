using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.ViewModels.Identity;

namespace WebStore.Controlers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View(new RegisterUserViewModel());
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }


    }
}