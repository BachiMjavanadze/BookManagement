using BookManagement.Core.Interfaces;
using BookManagement.Core.Models;
using BookManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Repositories;

/// <summary>
/// Provides methods for accessing and managing User entities in the database.
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly BookManagementDbContext _context;

    public UserRepository(BookManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves a user by their username.
    /// </summary>
    /// <param name="username">The username to search for.</param>
    /// <returns>
    /// The <see cref="User"/> if found; otherwise, <c>null</c>.
    /// </returns>
    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Username == username);
    }

    /// <summary>
    /// Creates a new user in the database.
    /// </summary>
    /// <param name="user">The user entity to create.</param>
    /// <returns>
    /// The created <see cref="User"/> with its generated ID.
    /// </returns>
    public async Task<User> CreateAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}
