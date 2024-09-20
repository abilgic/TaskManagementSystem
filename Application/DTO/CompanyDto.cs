using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.DTO
{
    public class CompanyDto
    {
        public int Id { get; set; } // Unique identifier for the company

        public string Name { get; set; } // Name of the company

        public int UserLimit { get; set; } // Limit of users allowed for this company

        public int ProjectLimit { get; set; } // Limit of projects allowed for this company

        public DateTime CreatedDate { get; set; } // Date when the company was created

        public TimeSpan ActiveDuration { get; set; } // Duration the company is active

        public int AdminUserId { get; set; } // Administrator user ID for this company
    }
}
