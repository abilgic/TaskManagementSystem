using TaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Infrastructure.Models;
namespace TaskManagement.Infrastructure.SeedData
{
    public static class SeedData
    {
        public static async Task InitializeAsync(AppDbContext context)
        {
            // Ensure the database is created
            await context.Database.EnsureCreatedAsync();

            // Seed data if no companies exist
            if (!context.Companies.Any())
            {
                var adminUser = new User
                {
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "admin@example.com",
                    Username = "admin",
                    Password = "hashedpassword", // Ensure to hash this properly
                    IsAdmin = true
                };

                context.Users.Add(adminUser);
                await context.SaveChangesAsync();

                var company = new Company
                {
                    Name = "Example Company",
                    UserLimit = 100,
                    ProjectLimit = 10,
                    ActiveDuration = TimeSpan.FromDays(30),
                    AdminUserId = adminUser.Id // Link the admin user
                };

                context.Companies.Add(company);
                await context.SaveChangesAsync();
            }
        }
    }


}
