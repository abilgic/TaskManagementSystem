using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Interfaces
{
    public interface ITaskRepository
    {
        System.Threading.Tasks.Task<IEnumerable<Domain.Entities.Task>> GetTasksByProjectIdAsync(int projectId);
        Task<Domain.Entities.Task> GetByIdAsync(int taskId);
        Task AddAsync(Domain.Entities.Task task);
        Task UpdateAsync(Domain.Entities.Task task);
        Task DeleteAsync(Domain.Entities.Task task);
    }
}
