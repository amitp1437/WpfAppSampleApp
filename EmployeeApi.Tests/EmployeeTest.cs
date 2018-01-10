﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeApi.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using EmployeeApi.Models;
using System.Collections.Generic;

namespace EmployeeApi.Tests
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void Employee_GetAllEmployeeDetails_Should_Return_All_Employees_Details()
        {
            var repo = new FakeEmployeeRepository();
            var controller = new EmployeeController(repo);
            var result = controller.GetAllEmployeeDetails() as OkNegotiatedContentResult<List<Employees>>;
            Assert.IsNotNull(result.Content);
        }
    }
}
