using BookManagement.Core.DTOs.AuthDTOs;
using BookManagement.Core.Models;

namespace BookManagement.Core.Interfaces;

public interface IJwtTokenService
{
    AuthResponseDto GenerateToken(User user);
}