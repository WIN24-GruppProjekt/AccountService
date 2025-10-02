using AccountService.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(UserManager<Users> userManager) : ControllerBase
{
    [HttpGet]
    [Route("instructor/get")]
    public async Task<IActionResult> GetAllInstructors()
    {
        var instructors = await userManager.GetUsersInRoleAsync("Instructor");
        var result = instructors.Select(instructor => new { instructor.FirstName, instructor.LastName });
                                                
        return Ok(result);
    }
}