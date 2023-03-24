using EmployeeManagement.Model;
using EmployeeManagement.Repository.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<InternalEmployee>> GetInternalEmployeesAsync()
        {
            return await _context.InternalEmployees
                .ToListAsync();
        }

        public async Task<InternalEmployee?> GetInternalEmployeeAsync(int employeeId)
        {
            return await _context.InternalEmployees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }

        public void AddInternalEmployee(InternalEmployee internalEmployee)
        {
            _context.InternalEmployees.Add(internalEmployee);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
