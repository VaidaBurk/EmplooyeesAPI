using EmplooyeesAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmplooyeesAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Employees)
                .WithOne()
                .HasForeignKey(e => e.CompanyId);
        }
    }
}
