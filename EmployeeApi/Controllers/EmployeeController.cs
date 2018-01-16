using EmployeeApi.Models;
using System;
using System.Security.Claims;
using System.Web.Http;
using System.Linq;
using System.Web.Http.Cors;

namespace EmployeeApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        private readonly IRepository repo;

        public EmployeeController(IRepository repo) 
        {
            this.repo = repo;
        }

        [Route("Getall")]
        [Authorize]
        public IHttpActionResult GetAllEmployeeDetails()
        {
            try
            {
                var result = repo.GetAllEmployee();
                return Ok(result);
            }
            catch (Exception ex)
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

        [Authorize(Roles = "admin")]
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

        [HttpGet]
        [Route("CheckUserCredetial")]
        public IHttpActionResult CheckUserCredetial(string userName, string password)
        {
            try
            {
                var data = repo.CheckUserCredetial(userName, password);
                return Ok(data);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [Authorize(Roles = "admin")]
        [Route("AddEmployee")]
        [HttpPost]
        public IHttpActionResult AddEmployee([FromBody] Employees emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                repo.AddEmployee(emp);
                return Created("Created at {uri}", new Employees { Id = emp.Id });
            }
            catch
            {
                return InternalServerError();
            }
        }

    }
}
