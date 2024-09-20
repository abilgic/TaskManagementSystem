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
        public Project Project { get; set; }
        public int? AssignedUserId { get; set; }
        public User AssignedUser { get; set; }
        public List<string> Tags { get; set; }
    }
}
