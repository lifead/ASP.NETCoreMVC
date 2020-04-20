﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Controllers;
using WebStore.Interfaces.Api;
using Assert = Xunit.Assert;

namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class WebAPITestControllerTests
    {
        [TestMethod]
        public async Task Index_Returns_View_Values()
        {
            var expected_result = new[] { "1", "2", "3" };

            var value_service_mock = new Mock<IValuesService>();
            value_service_mock
               .Setup(service => service.GetAsync())
               .ReturnsAsync(expected_result);

            var controller = new WebAPITestController(value_service_mock.Object);

            var result = await controller.Index();

            var view_result = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<string>>(view_result.Model);

            Assert.Equal(expected_result.Length, model.Count());

        }
    }
}