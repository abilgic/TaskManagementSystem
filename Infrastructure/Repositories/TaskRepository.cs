using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DbContext _context; // Replace with your actual DbContext type
        private readonly DbSet<Domain.Entities.Task> _taskSet;

        public TaskRepository(DbContext context) // Replace DbContext with your specific context type
        {
            _context = context;
            _taskSet = _context.Set<Domain.Entities.Task>();
        }

        public async Task<IEnumerable<Domain.Entities.Task>> GetTasksByProjectIdAsync(int projectId)
        {
            return await _taskSet
                .Where(t => t.ProjectId == projectId)
                .ToListAsync();
        }

        public async Task<Domain.Entities.Task> GetByIdAsync(int taskId)
        {
            return await _taskSet.FindAsync(taskId);
        }

        public async Task AddAsync(Domain.Entities.Task task)
        {
            await _taskSet.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.Entities.Task task)
        {
            _taskSet.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Domain.Entities.Task task)
        {
            _taskSet.Remove(task);
            await _context.SaveChangesAsync();
        }

       
    }
}
