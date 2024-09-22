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
    //public class Task
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public string Description { get; set; }
    //    public int EstimatedHours { get; set; }
    //    public int EffortHours { get; set; }
    //    public string Priority { get; set; }
    //    public TaskStatus Status { get; set; }

    //    // Relationships
    //    public int ProjectId { get; set; }
    //    public Project Project { get; set; }
    //    public int UserId { get; set; }
    //    public User AssignedUser { get; set; }
    //    public ICollection<string> Labels { get; set; }
    //}

    //public enum TaskStatus
    //{
    //    New,
    //    InDevelopment,
    //    InTesting,
    //    Completed
    //}


}
