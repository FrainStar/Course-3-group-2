using Microsoft.AspNetCore.Mvc;


namespace WebApplication2.Controllers;

public class TaskItem
{
    public int Id { get; set; }
    public string Name { get; set; }

    public TaskItem(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

[ApiController]
public class TaskController : Controller
{
    [HttpGet("api/tasks")]
    public IActionResult WriteTask()
    {
        return Ok(new TaskItem(2, "Boris"));
    }
}