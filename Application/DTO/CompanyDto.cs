using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.DTO
{
    public class CompanyDto
    {
        public string Name { get; set; }
        public int ProjectLimit { get; set; }
        public int UserLimit { get; set; }
        public DateTime ActiveUntil { get; set; }
    }
}
