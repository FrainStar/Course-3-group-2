using System.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Interfaces;
using WebApplication1.Models.Models;

namespace WebApplication1.Controllers;

public class UserController : Controller
{

    private readonly IUserManager _userManager;

    public UserController(IUserManager userManager)
    {
        _userManager = userManager;
    }
    
    [HttpPost("/api/users/register")]
    public IActionResult CreateUser([FromBody] UserModel user)
    {
        _userManager.CreateUser(user);
        return Ok("User created");
    }
    
    [HttpGet("/api/users/")]
    public IActionResult GetUsers()
    {
        return Ok(_userManager.GetAllUser());
    }


    [HttpPost("/api/users/update/{userId}")]
    public IActionResult UpdateUser(int userId, [FromBody] UserModel user)
    {
        string result = _userManager.UpdateUser(userId, user);
        if (result == "User not found")
        {
            return NotFound("User not found");
        }
        
        return Ok("User updated");
    }
    
    
}