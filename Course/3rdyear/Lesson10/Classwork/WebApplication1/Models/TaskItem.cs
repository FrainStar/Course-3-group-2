namespace WebApplication1.Models;

public class TaskItem
{
    public TaskItem(int id, string username, string description, bool isCompleted)
    {
        Id = id;
        Username = username;
        Description = description;
        IsCompleted = isCompleted;
    }

    public int Id { get; set; }
    public string Username { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

}