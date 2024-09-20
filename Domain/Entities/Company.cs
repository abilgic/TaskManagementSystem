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
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public int AdminUserId { get; set; } // Administrator user ID for this company
        public TimeSpan ActiveDuration { get; set; }
    }
}
