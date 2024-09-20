using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Infrastructure.Models;

namespace TaskManagement.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            // Use your connection string here
            optionsBuilder.UseSqlServer("Server=localhost;Database=TaskManagementDb;Trusted_Connection=True;TrustServerCertificate=True");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
