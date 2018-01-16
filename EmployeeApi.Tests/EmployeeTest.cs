using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeApi.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using EmployeeApi.Models;
using System.Collections.Generic;
using System.Net;
using Moq;

namespace EmployeeApi.Tests
{
    [TestClass]
    public class EmployeeTest
    {
        FakeEmployeeRepository repo = new FakeEmployeeRepository();
        [TestMethod]
        public void Employee_GetAllEmployeeDetails_Should_Return_All_Employees_Details()
        {
            var controller = new EmployeeController(repo);
            var result = controller.GetAllEmployeeDetails() as OkNegotiatedContentResult<List<Employees>>;
            Assert.IsNotNull(result.Content);
        }

        [TestMethod]
        public void Employee_GetAllEmployeeDetails_Should_Return_NotFound_When_Result_Is_Empty()
        {
            var mockData = new List<Employees>();
            var moq = new Mock<IRepository>();
            moq.Setup(x => x.GetAllEmployee()).Returns(mockData);
            var controller = new EmployeeController(moq.Object);
            var result = controller.GetAllEmployeeDetails();

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Employee_GetEmployeeById_Should_Return_Employee_Data()
        {
            var controller = new EmployeeController(repo);
            var result = controller.GetEmployeeById(1) as OkNegotiatedContentResult<Employees>;
            Assert.IsNotNull(result.Content);
        }

        [TestMethod]
        public void Employee_GetEmployeeById_Should_Return_NotFound_When_Result_Is_Empty()
        {
            var mockData = new Employees();
            mockData = null;
            var moq = new Mock<IRepository>();
            moq.Setup(x => x.GetEmployeeById(2)).Returns(mockData);
            var controller = new EmployeeController(moq.Object);
            var result = controller.GetEmployeeById(2);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Employee_CheckUserCredential_Should_Return_NotFoundException_If_UserCredtialsExistsInDatabase()
        {
            var mockData = new UserDetail();
            mockData = null;
            var moq = new Mock<IRepository>();
            moq.Setup(x => x.CheckUserCredetial(It.IsAny<string>(), It.IsAny<string>())).Returns(mockData);
            var controller = new EmployeeController(moq.Object);
            var result = controller.CheckUserCredential(string.Empty, string.Empty);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Employee_CheckUserCredential_Should_Return_OkResult_If_UserCredtialsExistsInDatabase()
        {
            var mockData = new UserDetail()
            {
                Username = "imran",
                Password = "12345"
            };
            var moq = new Mock<IRepository>();
            moq.Setup(x => x.CheckUserCredetial(It.IsAny<string>(), It.IsAny<string>())).Returns(mockData);

            var controller = new EmployeeController(moq.Object);
            var result = controller.CheckUserCredential("imran", "12345") as OkNegotiatedContentResult<UserDetail>;
            Assert.IsNotNull(result.Content);
        }
    }
}
