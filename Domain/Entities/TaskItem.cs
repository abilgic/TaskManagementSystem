using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int EstimatedHours { get; set; }
        public int EffortHours { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }
        public string Comments { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; } // Navigation property to Project
        public int? AssignedUserId { get; set; } // Nullable foreign key for User
        public User AssignedUser { get; set; } // Navigation property to User
        public List<string> Tags { get; set; } // List of tags for categorization
    }

}
