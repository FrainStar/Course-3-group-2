using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Managers.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskManager _taskManager;

        public TasksController(ITaskManager taskManager)
        {
            _taskManager = taskManager;
        }

        [HttpGet("get")]
        public async Task<List<TaskItem>> GetAllTasks()
        {
            return await _taskManager.GetAllTasksAsync();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTask([FromBody] TaskItem task)
        {
            await _taskManager.AddTaskAsync(task);
            return Ok("New task created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _taskManager.DeleteTaskAsync(id);
            if (task == null)
            {
                return NotFound("Task not found");
            }

            return Ok("Task deleted");
        }


        [HttpPost("update")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskItem task)
        {
            var existingTask = await _taskManager.UpdateTaskAsync(id, task);

            if (existingTask == null)
            {
                return NotFound("Task not found");
            }

            return Ok("Task updated");
        }
    }
}


