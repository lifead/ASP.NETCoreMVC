﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebStore.Controllers;

using Assert = Xunit.Assert;

namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Index_Returns_View()
        {
            var controller = new HomeController();
            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void SomeAction_Returns_View()
        {
            var controller = new HomeController();
            var result = controller.SomeAction();

            Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void ContactUs_Returns_View()
        {
            var controller = new HomeController();
            var result = controller.ContactUs();

            Assert.IsType<ViewResult>(result);
        }
    }
}
