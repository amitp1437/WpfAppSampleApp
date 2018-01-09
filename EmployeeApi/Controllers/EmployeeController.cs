using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace EmployeeApi.Controllers
{
    public class EmployeeController : ApiController
    {
        [Route("api/employee/Getall")]
        public IHttpActionResult GetAllEmployeeDetails()
        {
            return Ok("Employee Data is unavailable currently");
        }

        [Authorize]
        [Route("api/employee/Authenticate")]
        public IHttpActionResult GetAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok(identity);
        }

        [Authorize(Roles = "user")]
        public IHttpActionResult GetEmployeeById()
        {
            return Ok("Employee data is currently not available");
        }

    }
}
