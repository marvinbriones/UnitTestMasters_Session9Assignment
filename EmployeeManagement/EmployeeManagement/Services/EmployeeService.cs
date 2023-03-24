using EmployeeManagement.Model;
using EmployeeManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<InternalEmployee?> FetchInternalEmployeeAsync(int employeeId)
        {
            var employee = await _repository.GetInternalEmployeeAsync(employeeId);
            return employee;
        }

        public async Task<IEnumerable<InternalEmployee>> FetchInternalEmployeesAsync()
        {
            var employees = await _repository.GetInternalEmployeesAsync();
            return employees;
        }

        public async Task AddInternalEmployeeAsync(InternalEmployee internalEmployee)
        {
            _repository.AddInternalEmployee(internalEmployee);
            await _repository.SaveChangesAsync();
        }
    }
}
