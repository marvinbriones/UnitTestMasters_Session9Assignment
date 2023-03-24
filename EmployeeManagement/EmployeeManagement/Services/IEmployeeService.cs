using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public interface IEmployeeService
    {
        Task<InternalEmployee?> FetchInternalEmployeeAsync(int employeeId);
        Task<IEnumerable<InternalEmployee>> FetchInternalEmployeesAsync();
        Task AddInternalEmployeeAsync(InternalEmployee internalEmployee);
    }
}
