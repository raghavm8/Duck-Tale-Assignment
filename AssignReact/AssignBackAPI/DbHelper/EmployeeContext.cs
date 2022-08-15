using Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment.DBHelper
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<EmployeeModel> employees { get; set; }

    }
}
