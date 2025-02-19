namespace BookManagement.Core.DTOs.AuthDTOs;

public class AuthResponseDto
{
    public string Token { get; set; } = null!;
    public string Username { get; set; } = null!;
    public DateTime ExpiresAt { get; set; }
}
