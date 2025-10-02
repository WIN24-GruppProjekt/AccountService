using System.ComponentModel.DataAnnotations;

namespace AccountService.Data.Models;

public class RegisterCustomerDto
{
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    [Phone]
    public string Phone { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    
    public string? ImgUrl { get; set; }
    
}