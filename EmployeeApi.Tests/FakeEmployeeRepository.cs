using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApi.Models;

namespace EmployeeApi.Tests
{
    public class FakeEmployeeRepository : IRepository
    {
        public void AddEmployee(Employees emp)
        {
            throw new NotImplementedException();
        }

        public UserDetail CheckUserCredetial(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public List<Employees> GetAllEmployee()
        {
            var data = new List<Employees>()
            {
               new Employees
               {
                   FirstName = "Deo",
                   LastName = "P",
                   Gender = "M",
                   Salary = 1500
               }  
            };
            return data;
        }

        public Employees GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
