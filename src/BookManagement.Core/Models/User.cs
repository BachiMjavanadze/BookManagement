using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagement.Core.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    [Length(1, 50, ErrorMessage = "Username must be between {1} and {2} characters")]
    [Column(TypeName = "nvarchar(50)")]
    public string Username { get; set; } = null!;

    [Column(TypeName = "nvarchar(max)")]
    public string PasswordHash { get; set; } = null!;
}
