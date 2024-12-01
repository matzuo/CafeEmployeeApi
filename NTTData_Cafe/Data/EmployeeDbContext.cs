using Microsoft.EntityFrameworkCore;
using NTTData_Cafe.Models.DataModels;

namespace NTTData_Cafe.Data
{
    public class EmployeeDbContext : DbContext
  {
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
  }
}
