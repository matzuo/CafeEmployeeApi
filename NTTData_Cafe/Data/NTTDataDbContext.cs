using Microsoft.EntityFrameworkCore;
using NTTData_Cafe.Models.DataModels;

namespace NTTData_Cafe.Data
{
    public class NTTDataDbContext : DbContext
  {
    public NTTDataDbContext(DbContextOptions<NTTDataDbContext> options)
            : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Cafe> Cafes { get; set; }

  }
}
