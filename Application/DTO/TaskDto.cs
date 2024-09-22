using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.DTO
{
    public class TaskDto
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public int EstimatedHours { get; set; }
        public int EffortHours { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Tags { get; set; }
        public int ProjectId { get; set; }
        public int AssignedToUserId { get; set; }
    }
}
