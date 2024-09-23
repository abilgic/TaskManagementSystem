using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Interfaces
{
    public interface ITaskRepository
    {
        public Task<List<Domain.Entities.Task>> GetTasksByProjectIdAsync(int projectId);


        // Get task by TaskId
        public Task<Domain.Entities.Task> GetTaskByIdAsync(int taskId);


        // Add a new task
        public Task AddTaskAsync(Domain.Entities.Task task);


        // Update a task
        public Task UpdateTaskAsync(Domain.Entities.Task task);


        // Delete a task by its ID
        public Task DeleteTaskAsync(Domain.Entities.Task task);


    }
}
