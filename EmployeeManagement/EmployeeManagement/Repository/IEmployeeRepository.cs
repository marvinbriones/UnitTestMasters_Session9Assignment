using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<InternalEmployee>> GetInternalEmployeesAsync();
        Task<InternalEmployee?> GetInternalEmployeeAsync(int employeeId);
        void AddInternalEmployee(InternalEmployee internalEmployee);
        Task SaveChangesAsync();
    }
}
