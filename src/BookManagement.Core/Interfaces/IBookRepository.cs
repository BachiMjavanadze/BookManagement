using BookManagement.Core.Models;

namespace BookManagement.Core.Interfaces;

public interface IBookRepository
{
    Task<Book> GetDetailsByIdAsync(int id);
    Task<IEnumerable<Book>> GetDetailsByNameAsync(string searchTerm);
    Task<bool> TitleExistsAsync(string title);
    Task<IEnumerable<Book>> GetAllAsync(int page, int pageSize);
    Task<Book> AddAsync(Book book);
    Task AddRangeAsync(IEnumerable<Book> books);
    Task<Book> UpdateAsync(Book book);
    Task SoftDeleteAsync(int id);
    Task SoftDeleteRangeAsync(IEnumerable<int> ids);
}