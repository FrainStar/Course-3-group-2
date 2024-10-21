using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskContext _context;

        public TasksController(TaskContext context)
        {
            _context = context;
        }

        [HttpGet("get")]
        public async Task<IEnumerable<TaskItem>> GetAllTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTask([FromBody] TaskItem task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return Ok("New task created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound("Task not found");
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return Ok("Task deleted");
        }


        [HttpPost("update")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskItem task)
        {
            var existingTask = await _context.Tasks.FindAsync(id);
    
            if (existingTask == null)
            {
                return NotFound("Task not found");
            }
            
            existingTask.Username = task.Username;
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;

            await _context.SaveChangesAsync();

            return Ok("Task updated");
        }
    }
}


