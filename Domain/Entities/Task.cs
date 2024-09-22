using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int EstimatedHours { get; set; }
        public int EffortHours { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public string Comments { get; set; }
        public int ProjectId { get; set; }
        public string Tags { get; set; }

        public int? AssignedToUserId { get; set; }
        public User AssignedToUser { get; set; } // Navigation property
    }


}
