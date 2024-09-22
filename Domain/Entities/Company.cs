using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectLimit { get; set; }
        public int UserLimit { get; set; }
        public DateTime ActiveUntil { get; set; }
        public int AdminUserId { get; set; }
        public int ActiveDurationDays { get; set; } // Change to int for days
    }
    //public class Company
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public int MaxProjects { get; set; } // Limit for projects
    //    public int MaxUsers { get; set; } // Limit for users
    //    public DateTime ActiveUntil { get; set; } // Active duration

    //    // Relationships
    //    public User AdminUser { get; set; } // Company Admin
    //    public ICollection<Project> Projects { get; set; }
    //    public ICollection<User> Users { get; set; }
    //}
}
