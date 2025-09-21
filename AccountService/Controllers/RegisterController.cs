using AccountService.Data.Entities;
using AccountService.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegisterController(UserManager<Users> userManager) : ControllerBase
{
    /// <summary>
       /// Registers a new instructor account and assigns the "Instructor" role.
       /// Expects a <see cref="RegisterInstructorDto"/> in the request body.
       /// Returns 200 OK on success, 400 BadRequest with identity errors on failure.
       /// </summary>
    [HttpPost]
    [Route("instructor")]
    public async Task<IActionResult> RegisterInstructor([FromBody] RegisterInstructorDto registrationForm)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var instructor = new Users
        {
            UserName = registrationForm.Email,
            Email = registrationForm.Email,
            FirstName = registrationForm.FirstName,
            LastName = registrationForm.LastName,
            PhoneNumber = registrationForm.Phone
        };

        var results = await userManager.CreateAsync(instructor, registrationForm.Password);
        
        if (!results.Succeeded)
        {
            return BadRequest(results.Errors);
        }
        
        var roleResult = await userManager.AddToRoleAsync(instructor, "Instructor");

        if (!roleResult.Succeeded)
        {
            return BadRequest(roleResult.Errors);
        }
        
        
        return Ok(new { Message = "Instructor Successfully Created" });
    }
    
    /// <summary>
    /// Registers a new customer account and assigns the "Customer" role.
    /// Expects a <see cref="RegisterInstructorDto"/> in the request body.
    /// Returns 200 OK on success, 400 BadRequest with identity errors on failure.
    /// </summary>
    [HttpPost]
    [Route("customer")]
    public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerDto registrationForm)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var customer = new Users
        {
            UserName = registrationForm.Email,
            Email = registrationForm.Email,
            FirstName = registrationForm.FirstName,
            LastName = registrationForm.LastName,
            PhoneNumber = registrationForm.Phone
        };

        var results = await userManager.CreateAsync(customer, registrationForm.Password);

        if (!results.Succeeded)
        {
            return BadRequest(results.Errors);
        }
        
        var roleResult = await userManager.AddToRoleAsync(customer, "Customer");

        if (!roleResult.Succeeded)
        {
            return BadRequest(roleResult.Errors);
        }
        
        return Ok(new { Message = "Customer Successfully Created" });
    }
}