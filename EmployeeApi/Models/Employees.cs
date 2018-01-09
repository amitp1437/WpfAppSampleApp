using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApi.Models
{
    public class Employees
    {
        [key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int salary { get; set; }
    }
}