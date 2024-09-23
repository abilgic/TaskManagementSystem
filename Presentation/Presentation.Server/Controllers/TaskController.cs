using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/task/{projectId}
        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetTasksByProjectId(int projectId)
        {
            var tasks = await _taskService.GetTasksByProjectIdAsync(projectId);
            return Ok(tasks);
        }

        // POST: api/task
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] Domain.Entities.Task newTask)
        {
            if (newTask == null)
            {
                return BadRequest("Invalid task data");
            }

            var createdTask = await _taskService.CreateTaskAsync(newTask);
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        // PUT: api/task/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] Domain.Entities.Task updatedTask)
        {
            if (updatedTask == null)
            {
                return BadRequest("Invalid task data");
            }

            var task = await _taskService.UpdateTaskAsync(id, updatedTask);
            return Ok(task);
        }

        // DELETE: api/task/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTaskAsync(id);
            return NoContent();
        }

        // GET: api/task/{id}
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }
    }
}
