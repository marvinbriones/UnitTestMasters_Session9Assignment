using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model
{
    public class InternalEmployee : Employee
    {
        public int YearsInService { get; set; }
        public decimal Salary { get; set; }
        public int JobLevel { get; set; }
    }
}
