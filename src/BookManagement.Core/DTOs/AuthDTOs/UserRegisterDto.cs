using System.ComponentModel.DataAnnotations;

namespace BookManagement.Core.DTOs.AuthDTOs;

public class UserRegisterDto
{
    [Required]
    [Length(1, 50, ErrorMessage = "Username must be between {1} and {2} characters")]
    [RegularExpression(@"^[a-zA-Z0-9_-]+$", ErrorMessage = "Username can only contain letters, numbers, underscores, and hyphens")]
    public string Username { get; set; } = null!;

    [Required]
    [Length(6, 100, ErrorMessage = "Password must be between {1} and {2} characters")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character")]
    public string Password { get; set; } = null!;

    [Required]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = null!;
}