using EmployeeManagement.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model
{
    public abstract class Employee
    {
        public int EmployeeId { get; set; }
        public int EmployeeTypeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreateDate { get; set; }
        public List<IEvent> Events { get; set; } = new List<IEvent>();
    }
}
