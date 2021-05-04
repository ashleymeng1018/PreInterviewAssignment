using DataStorage.Models;
using System.Collections.Generic;
using System.Linq;

namespace BackendAPI.Interfaces
{
    public class EmployeeRepo : IEmployee
    {
        private readonly SFExpressContext _dbContext;

        public EmployeeRepo(SFExpressContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Create
        public void AddNewEmployee(Employee newEmployee)
        {
            _dbContext.Employee.Add(newEmployee);
            _dbContext.SaveChanges();
        }

        //Delete
        public void DeleteEmployee(Employee employeeToDelete)
        {
            _dbContext.Employee.Remove(employeeToDelete);
            _dbContext.SaveChanges();
        }

        //Read
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _dbContext.Employee.ToList();
        }

        //Update
        public void UpdateEmployeeInfo()
        {
            _dbContext.SaveChanges();
        }
    }

    
   
  
}
