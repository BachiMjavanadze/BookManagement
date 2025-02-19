using BookManagement.Core.DTOs.BookDTOs;
using BookManagement.Core.Exceptions;
using BookManagement.Core.Interfaces;
using BookManagement.Core.Models;
using BookManagement.Core.Mappers;

namespace BookManagement.Infrastructure.Services;

/// <summary>
/// Provides business logic and operations for managing books.
/// </summary>
public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    /// <summary>
    /// Retrieves the detailed information of a book by its ID.
    /// </summary>
    /// <param name="id">The ID of the book.</param>
    /// <returns>A <see cref="BookDetailsDto"/> containing the book's details.</returns>
    /// <exception cref="NotFoundException">Thrown if a book with the specified ID is not found.</exception>
    public async Task<BookDetailsDto> GetDetailsByIdAsync(int id)
    {
        var book = await _bookRepository.GetDetailsByIdAsync(id);
        if (book == null)
            throw new NotFoundException($"Book with ID {id} not found");

        return book.ToBookDetailsDto();
    }

    /// <summary>
    /// Retrieves detailed information for books whose title or author contains the specified search term.
    /// </summary>
    /// <param name="searchTerm">The term to search for in book titles or author names.</param>
    /// <returns>A collection of <see cref="BookDetailsDto"/> objects matching the search criteria.</returns>
    /// <exception cref="BadRequestException">Thrown if the search term is null or empty.</exception>
    public async Task<IEnumerable<BookDetailsDto>> GetDetailsByNameAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            throw new BadRequestException("Search term cannot be empty");

        var books = await _bookRepository.GetDetailsByNameAsync(searchTerm);
        return books.ToBookDetailsDtoList();
    }

    /// <summary>
    /// Retrieves a paginated list of book titles.
    /// </summary>
    /// <param name="page">The page number (1-based).</param>
    /// <param name="pageSize">The number of books per page.</param>
    /// <returns>A collection of <see cref="BookTitleDto"/> for the specified page.</returns>
    /// <exception cref="BadRequestException">Thrown if the page number or page size is less than 1.</exception>
    public async Task<IEnumerable<BookTitleDto>> GetAllAsync(int page, int pageSize)
    {
        if (page < 1)
            throw new BadRequestException("Page number must be greater than 0");
        if (pageSize < 1)
            throw new BadRequestException("Page size must be greater than 0");

        var books = await _bookRepository.GetAllAsync(page, pageSize);
        return books.ToBookTitleDtoList();
    }

    /// <summary>
    /// Adds a new book to the system.
    /// </summary>
    /// <param name="dto">The data transfer object containing book creation data.</param>
    /// <returns>A <see cref="BookDto"/> representing the newly created book.</returns>
    /// <exception cref="DuplicateTitleException">Thrown if a book with the same title already exists.</exception>
    public async Task<BookDto> AddAsync(BookCreateDto dto)
    {
        if (await _bookRepository.TitleExistsAsync(dto.Title))
            throw new DuplicateTitleException(dto.Title);

        var book = dto.ToBook();
        var addedBook = await _bookRepository.AddAsync(book);
        return addedBook.ToBookDto();
    }

    /// <summary>
    /// Adds multiple new books to the system.
    /// </summary>
    /// <param name="dtos">A collection of data transfer objects for creating books.</param>
    /// <exception cref="DuplicateTitleException">Thrown if one or more books have titles that already exist.</exception>
    public async Task AddRangeAsync(IEnumerable<BookCreateDto> dtos)
    {
        var books = new List<Book>();

        foreach (var dto in dtos)
        {
            if (await _bookRepository.TitleExistsAsync(dto.Title))
                throw new DuplicateTitleException(dto.Title);

            books.Add(dto.ToBook());
        }

        await _bookRepository.AddRangeAsync(books);
    }

    /// <summary>
    /// Updates an existing book with new information.
    /// </summary>
    /// <param name="id">The ID of the book to update.</param>
    /// <param name="dto">The data transfer object containing updated book information.</param>
    /// <returns>A <see cref="BookDto"/> representing the updated book.</returns>
    /// <exception cref="NotFoundException">Thrown if the book with the specified ID is not found.</exception>
    /// <exception cref="DuplicateTitleException">Thrown if the new title conflicts with an existing book's title.</exception>
    public async Task<BookDto> UpdateAsync(int id, BookUpdateDto dto)
    {
        var existingBook = await _bookRepository.GetDetailsByIdAsync(id);
        if (existingBook == null)
            throw new NotFoundException($"Book with ID {id} not found");

        if (existingBook.Title != dto.Title && await _bookRepository.TitleExistsAsync(dto.Title))
            throw new DuplicateTitleException(dto.Title);

        var updatedEntity = dto.ToBook(id);
        updatedEntity.ViewsCount = existingBook.ViewsCount;
        updatedEntity.IsDeleted = existingBook.IsDeleted;
        var updatedBook = await _bookRepository.UpdateAsync(updatedEntity);

        return updatedBook.ToBookDto();
    }

    /// <summary>
    /// Soft deletes a book by marking it as deleted.
    /// </summary>
    /// <param name="id">The ID of the book to delete.</param>
    /// <exception cref="NotFoundException">Thrown if the book is not found.</exception>
    public async Task SoftDeleteAsync(int id)
    {
        try
        {
            await _bookRepository.SoftDeleteAsync(id);
        }
        catch (KeyNotFoundException)
        {
            throw new NotFoundException($"Book with ID {id} not found");
        }
    }

    /// <summary>
    /// Soft deletes multiple books by marking them as deleted.
    /// </summary>
    /// <param name="ids">A collection of book IDs to delete.</param>
    /// <exception cref="NotFoundException">Thrown if one or more books are not found.</exception>
    public async Task SoftDeleteRangeAsync(IEnumerable<int> ids)
    {
        try
        {
            await _bookRepository.SoftDeleteRangeAsync(ids);
        }
        catch (KeyNotFoundException)
        {
            throw new NotFoundException("One or more books not found");
        }
    }
}