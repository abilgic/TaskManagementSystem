using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public bool IsAdmin { get; set; }
        public string Email { get; set; }

        // Use fully qualified name for Task
        public List<string> Roles { get; set; } = new List<string>();
        public ICollection<TaskManagement.Domain.Entities.Task> Tasks { get; set; } = new List<TaskManagement.Domain.Entities.Task>();
    }
    //public class User
    //{
    //    public int Id { get; set; }
    //    public string Username { get; set; }
    //    public string PasswordHash { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public bool IsAdmin { get; set; } // Determines if user is a company admin

    //    // Relationships
    //    public int CompanyId { get; set; }
    //    public Company Company { get; set; }
    //    public ICollection<Task> Tasks { get; set; }
    //}


}
