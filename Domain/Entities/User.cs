using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Entities
{
    public class User
    {
        public int Id { get; set; } // Unique identifier for the user
        public string FirstName { get; set; } // User's first name
        public string LastName { get; set; } // User's last name
        public string Email { get; set; } // User's email address
        public string Username { get; set; } // Username for login
        public string Password { get; set; } // Hashed password for security
        public bool IsAdmin { get; set; } // Indicates if the user is an admin
        public int CompanyId { get; set; } // Foreign key linking to the user's company
        public Company Company { get; set; } // Navigation property for the company
        public ICollection<TaskItem> AssignedTasks { get; set; } // Tasks assigned to the user
        public DateTime CreatedAt { get; set; } // Date the user was created
        public DateTime LastLogin { get; set; } // Timestamp of the last login
    }


}
