using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<List<Project>> GetProjectsByCompanyIdAsync(int companyId);
        Task<Company> CreateCompanyAsync(Company company);
        Task<bool> AnyAsync(System.Linq.Expressions.Expression<Func<Company, bool>> predicate);
    }

}
