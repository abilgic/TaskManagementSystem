using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Interfaces
{
    public interface ITaskService
    {        
        Task<IEnumerable<Domain.Entities.Task>> GetTasksByProjectIdAsync(int projectId);
        Task<Domain.Entities.Task> CreateTaskAsync(Domain.Entities.Task newTask);
        Task<Domain.Entities.Task> UpdateTaskAsync(int taskId, Domain.Entities.Task updatedTask);
        Task DeleteTaskAsync(int taskId);
        Task<Domain.Entities.Task> GetTaskByIdAsync(int taskId);
    }
}
