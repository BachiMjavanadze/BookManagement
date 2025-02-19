using BookManagement.Core.DTOs.BookDTOs;

namespace BookManagement.Core.Interfaces;

public interface IBookService
{
    Task<BookDetailsDto> GetDetailsByIdAsync(int id);
    Task<IEnumerable<BookDetailsDto>> GetDetailsByNameAsync(string searchTerm);
    Task<IEnumerable<BookTitleDto>> GetAllAsync(int page, int pageSize);
    Task<BookDto> AddAsync(BookCreateDto dto);
    Task AddRangeAsync(IEnumerable<BookCreateDto> dtos);
    Task<BookDto> UpdateAsync(int id, BookUpdateDto dto);
    Task SoftDeleteAsync(int id);
    Task SoftDeleteRangeAsync(IEnumerable<int> ids);
}
