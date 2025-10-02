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
        var result = instructors.Select(instructor => new { instructor.FirstName, instructor.LastName, instructor.ImgUrl });
                                                
        return Ok(result);
    }
    
    [HttpGet("instructor/{id}")]
    public async Task<IActionResult> GetInstructorById(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user is null)
            return NotFound();

        var isInstructor = await userManager.IsInRoleAsync(user, "Instructor");
        if (!isInstructor)
            return NotFound();

        return Ok(new
        {
            user.Id,
            user.FirstName,
            user.LastName,
            user.ImgUrl,
        });
    }
}