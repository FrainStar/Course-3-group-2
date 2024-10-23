using Microsoft.EntityFrameworkCore;
using WebApplication1.Managers.Interfaces;
using WebApplication1.Models;
namespace WebApplication1.Managers.Implemantations;


public class TaskManager : ITaskManager
{
    private readonly TaskContext _context;

    public TaskManager(TaskContext context)
    {
        _context = context;
    }

    public async Task<List<TaskItem>> GetAllTasksAsync()
    {
        return await _context.Tasks.ToListAsync();
    }
    
    public async Task<TaskItem> AddTaskAsync(TaskItem task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<TaskItem> DeleteTaskAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            return null;
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return task;
    }


    public async Task<TaskItem> UpdateTaskAsync(int id, TaskItem task)
    {
        var existingTask = await _context.Tasks.FindAsync(id);
    
        if (existingTask == null)
        {
            return null;
        }
            
        existingTask.Username = task.Username;
        existingTask.Description = task.Description;
        existingTask.IsCompleted = task.IsCompleted;

        await _context.SaveChangesAsync();
        return existingTask;
    }
}