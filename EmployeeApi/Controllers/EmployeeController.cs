using EmployeeApi.Models;
using System;
using System.Security.Claims;
using System.Web.Http;
using System.Linq;

namespace EmployeeApi.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        EmployeeRepository repo = new EmployeeRepository();

        [Route("Getall")]
        public IHttpActionResult GetAllEmployeeDetails()
        {
            try
            {              
                var result = repo.GetAllEmployee();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Authorize]
        [Route("Authenticate")]
        public IHttpActionResult GetAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello " + identity);
        }

        [Authorize(Roles = "user")]
        [Route("GetEmployeeById")]
        public IHttpActionResult GetEmployeeById(int id)
        {
            try
            {
                var data = repo.GetEmployeeById(id);

                return Ok(data);
            }
            catch
            {
                return InternalServerError();
            }
        }

    }
}
