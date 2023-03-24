using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model
{
    public class ExternalEmployee : Employee
    {
        public string? Company { get; set; }
    }
}
