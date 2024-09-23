using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Interfaces;

using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
namespace TaskManagement.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Task>> GetTasksByProjectIdAsync(int projectId)
        {
            return await _taskRepository.GetTasksByProjectIdAsync(projectId);
        }

        public async Task<Domain.Entities.Task> CreateTaskAsync(Domain.Entities.Task newTask)
        {
            await _taskRepository.AddAsync(newTask);
            return newTask;
        }

        public async Task<Domain.Entities.Task> UpdateTaskAsync(int taskId, Domain.Entities.Task updatedTask)
        {
            var existingTask = await _taskRepository.GetByIdAsync(taskId);
            if (existingTask == null) throw new KeyNotFoundException("Task not found");
            
            existingTask.Description = updatedTask.Description;
            // Update other fields as necessary

            await _taskRepository.UpdateAsync(existingTask);
            return existingTask;
        }

        public async System.Threading.Tasks.Task DeleteTaskAsync(int taskId)
        {
            var task = await _taskRepository.GetByIdAsync(taskId);
            if (task == null) throw new KeyNotFoundException("Task not found");

            await _taskRepository.DeleteAsync(task);
        }

        public async Task<Domain.Entities.Task> GetTaskByIdAsync(int taskId)
        {
            var task = await _taskRepository.GetByIdAsync(taskId);
            if (task == null) throw new KeyNotFoundException("Task not found");

            return task;
        }

        
    }
}
