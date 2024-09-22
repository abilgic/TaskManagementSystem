using TaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Infrastructure.Models;
namespace TaskManagement.Infrastructure.SeedData
{
    public static class SeedData
    {
        public static async System.Threading.Tasks.Task InitializeAsync(AppDbContext context)
        {
            // Ensure the database is created
            await context.Database.EnsureCreatedAsync();

            // Use a transaction for data integrity
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                // Seed companies if none exist
                if (!context.Companies.Any())
                {
                    var company = new Company
                    {
                        Name = "Example Company",
                        UserLimit = 100,
                        ProjectLimit = 10,
                        ActiveDurationDays = 30, // Set the duration in days
                        ActiveUntil = DateTime.UtcNow.AddDays(30), // Calculate ActiveUntil
                        AdminUserId = 0 // Set the AdminUserId appropriately
                    };

                    context.Companies.Add(company);
                    await context.SaveChangesAsync();

                    // Set AdminUserId after saving the company to get the generated Id
                    company.AdminUserId = company.Id;
                    context.Companies.Update(company);
                    await context.SaveChangesAsync();
                }

                // Get the company ID for seeding users
                var exampleCompany = await context.Companies.FirstOrDefaultAsync();

                // Seed users if none exist
                if (!context.Users.Any())
                {
                    var adminUser = new User
                    {
                        FirstName = "Admin",
                        LastName = "User",
                        Email = "admin@example.com",
                        Username = "admin",
                        Password = "admin", // Hash the password
                        CompanyId = exampleCompany.Id, // Link to the example company
                        IsAdmin = true,
                        Roles = new List<string> { "Admin", "Manager" } // Example roles
                    };

                    var regularUser = new User
                    {
                        FirstName = "Regular",
                        LastName = "User",
                        Email = "user@example.com",
                        Username = "user",
                        Password = "user", // Hash the password
                        CompanyId = exampleCompany.Id, // Link to the same company
                        IsAdmin = false,
                        Roles = new List<string> { "User" } // Example roles
                    };

                    context.Users.Add(adminUser);
                    context.Users.Add(regularUser);
                    await context.SaveChangesAsync();
                }

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw; // Re-throw the exception after rollback
            }
        }

    }

}




