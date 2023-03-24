using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Logger
{
    public interface IDomainLogger
    {
        void EmployeeTypeHasChanged(int employeeId, int oldType, int newType);
    }
}
