using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApi.Models
{
    public class EmployeeRepository
    {
        EmpContext context = new EmpContext();
        public List<Employees> GetAllEmployee()
        {
            var employees = new List<Employees>();
            employees = context.Employees.ToList();
            return employees;
        }

        public Employees GetEmployeeById(int id)
        {
            var data = context.Employees.Where(e => e.Id == id);

            return data.SingleOrDefault();
        }

        internal void AddEmployee(Employees emp)
        {
            context.Employees.Add(emp);
            context.SaveChanges();
        }

        public UserDetail CheckUserCredetial(string userName, string password)
        {
            var data = context.UserDetails.Where(e => e.Username == userName && e.Password == password);

            return data.FirstOrDefault();
        }
    }
}