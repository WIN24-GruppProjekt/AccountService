using AccountService.Data.Entities;
using AccountService.Data.Models;
using AccountService.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController(UserManager<Users> userManager, SignInManager<Users> signInManager, JwtService jwtService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserLoginDto loginForm)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var user = await userManager.FindByEmailAsync(loginForm.Email);
        if (user == null)
            return Unauthorized(new { Message = "User Not Found" });
        
        var results = await signInManager.CheckPasswordSignInAsync(
            user,
            loginForm.Password,
            lockoutOnFailure: false
        );

        if (!results.Succeeded)
        {
            return Unauthorized(new { Message = "Invalid Credentials" });
        }
        
        var token = await jwtService.GenerateJwtAsync(user);
        return Ok(new { token });
    }
}