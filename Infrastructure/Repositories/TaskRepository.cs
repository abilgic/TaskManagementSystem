using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Models;

namespace TaskManagement.Infrastructure.Repositories
{
    public class TaskRepository : Repository<Domain.Entities.Task>, ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context) : base(context)
        {
            _context = context;  // Now uses AppDbContext instead of DbContext
        }

        // Get tasks by ProjectId
        public async Task<List<Domain.Entities.Task>> GetTasksByProjectIdAsync(int projectId)
        {
            var list = await GetAllAsync();
            return list.Where(t => t.ProjectId == projectId).ToList();
        }

        // Get task by TaskId
        public async Task<Domain.Entities.Task> GetTaskByIdAsync(int taskId)
        {
            return await GetByIdAsync(taskId);
        }

        // Add a new task
        public async Task AddTaskAsync(Domain.Entities.Task task)
        {
            await AddAsync(task);
        }

        // Update a task
        public async Task UpdateTaskAsync(Domain.Entities.Task task)
        {
            await UpdateAsync(task);
        }

        // Delete a task by its ID
        public async Task DeleteTaskAsync(Domain.Entities.Task task)
        {            
            if (task != null)
            {
                await DeleteAsync(task);
            }
        }
    }
}
