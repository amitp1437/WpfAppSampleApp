using EmployeeApi.Models;
using System;
using System.Security.Claims;
using System.Web.Http;
using System.Linq;
using System.Web.Http.Cors;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        //private readonly IRepository repo;

        public EmployeeController()//EmployeeController(IRepository repo) 
        {
            //this.repo = repo;
        }

        [Route("Getall")]
        //[Authorize]
        public async Task<IHttpActionResult> GetAllEmployeeDetails()
        {
            try
            {
                //var employeeService = new EmployeeServiceClient();
                //var result = employeeService.GetAllEmployee();
                //var result = repo.GetAllEmployee();
                //return Ok(result);
                Uri geturi = new Uri("http://localhost:51931/EmployeeService.svc/GetAllEmployee");
                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                System.Net.Http.HttpResponseMessage responseGet = await client.GetAsync(geturi);
                string response = await responseGet.Content.ReadAsStringAsync();
                return Ok(response);
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
                //var data = repo.GetEmployeeById(id);
                //return Ok(data);
                return Ok();
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
                //var data = repo.CheckUserCredetial(userName, password);
                //return Ok(data);
                return Ok();
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
                //repo.AddEmployee(emp);
                //return Created("Created at {uri}", new Employees { Id = emp.Id });
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
        }

    }
}
