using System;
using System.Collections.Generic;

namespace DataStorage.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? HiredDate { get; set; }
        public string Tasks { get; set; }
    }
}
