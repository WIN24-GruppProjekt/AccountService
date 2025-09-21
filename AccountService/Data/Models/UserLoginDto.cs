using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AccountService.Data.Models;

public class UserLoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    [PasswordPropertyText]
    public string Password { get; set; } = null!;
}