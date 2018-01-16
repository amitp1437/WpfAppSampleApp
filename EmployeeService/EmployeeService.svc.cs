using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository repository;
        public EmployeeService(IRepository repo)
        {
            this.repository = repo;
        }
        public bool AddEmployee(EmployeeDataContract employee)
        {
            repository.AddEmployee(employee);
            return true;
        }

        public bool DeleteEmployee(EmployeeDataContract employee)
        {
            repository.DeleteEmployee(employee);
            return true;
        }

        public List<EmployeeDataContract> GetAllEmployee()
        {
            var result = repository.GetAllEmployee();
            return result.ToList<EmployeeDataContract>();
        }

        public EmployeeDataContract GetEmployeeByID(string employeeID)
        {
            var result = repository.GetEmployeeById(Convert.ToInt32(employeeID));
            return result;
        }

        public bool UpdateEmmployee(EmployeeDataContract employee)
        {
            repository.UpdateEmployee(employee);
            return true;
        }
    }
}
