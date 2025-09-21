using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AccountService.Data.Entities;

public class Users : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "nvarchar(50)")]
    public string FirstName { get; set; } = null!;
    
    [PersonalData]
    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; } = null!;
}