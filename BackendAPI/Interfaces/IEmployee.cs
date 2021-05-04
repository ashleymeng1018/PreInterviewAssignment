using BackendAPI.Models;
using DataStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Interfaces
{
    public interface IEmployee
    {
        // Read
        IEnumerable<Employee> GetAllEmployees();

        //Create
        void AddNewEmployee(Employee newEmployee);


        //Update
        void UpdateEmployeeInfo();


        //Delete
        void DeleteEmployee(Employee employeeToDelete);


    }
}
