using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model
{
    public class Result
    {
        public bool Success { get; set; }
        public InternalEmployee Employee { get; set; }
    }
}
