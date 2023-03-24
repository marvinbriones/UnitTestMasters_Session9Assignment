using EmployeeManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.DbContexts
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<InternalEmployee> InternalEmployees { get; set; } = null!;
        public DbSet<ExternalEmployee> ExternalEmployees { get; set; } = null!;
    }
}
