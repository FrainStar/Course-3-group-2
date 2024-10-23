using WebApplication1.Models;

namespace WebApplication1.Managers.Interfaces;

public interface ITaskManager
{
    public Task<List<TaskItem>> GetAllTasksAsync();
    public Task<TaskItem> AddTaskAsync(TaskItem task);
    public Task<TaskItem> DeleteTaskAsync(int id);
    public Task<TaskItem> UpdateTaskAsync(int id, TaskItem task);
}