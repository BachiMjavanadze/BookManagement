using BookManagement.Core.Interfaces;
using BookManagement.Core.Models;
using BookManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Repositories;

/// <summary>
/// Repository for managing book entities in the database
/// </summary>
public class BookRepository : IBookRepository
{
    private readonly BookManagementDbContext _context;

    public BookRepository(BookManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves a book by its ID, increments its view count, and returns its details.
    /// </summary>
    /// <param name="id">The ID of the book to retrieve.</param>
    /// <returns>The <see cref="Book"/> matching the specified ID.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the book is not found.</exception>
    public async Task<Book> GetDetailsByIdAsync(int id)
    {
        var book = await _context.Books
            .FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

        if (book == null)
            throw new KeyNotFoundException($"Book with ID {id} not found");

        book.ViewsCount++;
        await _context.SaveChangesAsync();

        return book;
    }

    /// <summary>
    /// Retrieves books whose title or author name contains the specified search term.
    /// </summary>
    /// <param name="searchTerm">The term to search for.</param>
    /// <returns>A collection of <see cref="Book"/> objects that match the search criteria.</returns>
    public async Task<IEnumerable<Book>> GetDetailsByNameAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return Enumerable.Empty<Book>();

        return await _context.Books
            .Where(b => !b.IsDeleted &&
                (b.Title.Contains(searchTerm) || b.AuthorName.Contains(searchTerm)))
            .ToListAsync();
    }

    /// <summary>
    /// Checks whether a book with the specified title exists and is not marked as deleted.
    /// </summary>
    /// <param name="title">The title of the book.</param>
    /// <returns>
    ///   <c>true</c> if a book with the specified title exists; otherwise, <c>false</c>.
    /// </returns>
    public async Task<bool> TitleExistsAsync(string title)
    {
        return await _context.Books
            .AnyAsync(b => b.Title == title && !b.IsDeleted);
    }

    /// <summary>
    /// Retrieves a paginated list of books ordered by descending view count.
    /// </summary>
    /// <param name="page">The page number (1-based).</param>
    /// <param name="pageSize">The number of books per page.</param>
    /// <returns>A collection of <see cref="Book"/> objects.</returns>
    public async Task<IEnumerable<Book>> GetAllAsync(int page, int pageSize)
    {
        return await _context.Books
            .Where(b => !b.IsDeleted)
            .OrderByDescending(b => b.ViewsCount)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    /// <summary>
    /// Adds a new book to the database.
    /// </summary>
    /// <param name="book">The <see cref="Book"/> to add.</param>
    /// <returns>The added <see cref="Book"/> with its generated ID.</returns>
    public async Task<Book> AddAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    /// <summary>
    /// Adds multiple books to the database.
    /// </summary>
    /// <param name="books">A collection of <see cref="Book"/> objects to add.</param>
    public async Task AddRangeAsync(IEnumerable<Book> books)
    {
        _context.Books.AddRange(books);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Updates an existing book with new values.
    /// </summary>
    /// <param name="book">The <see cref="Book"/> object with updated information.</param>
    /// <returns>The updated <see cref="Book"/>.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the book is not found.</exception>
    public async Task<Book> UpdateAsync(Book book)
    {
        var existingBook = await _context.Books
            .FirstOrDefaultAsync(b => b.Id == book.Id && !b.IsDeleted);

        if (existingBook == null)
            throw new KeyNotFoundException($"Book with ID {book.Id} not found");

        existingBook.Title = book.Title;
        existingBook.AuthorName = book.AuthorName;
        existingBook.PublicationYear = book.PublicationYear;

        await _context.SaveChangesAsync();
        return existingBook;
    }

    /// <summary>
    /// Marks a book as deleted (soft delete).
    /// </summary>
    /// <param name="id">The ID of the book to delete.</param>
    /// <exception cref="KeyNotFoundException">Thrown if the book is not found.</exception>
    public async Task SoftDeleteAsync(int id)
    {
        var book = await _context.Books
            .FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

        if (book == null)
            throw new KeyNotFoundException($"Book with ID {id} not found");

        book.IsDeleted = true;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Marks multiple books as deleted (soft delete).
    /// </summary>
    /// <param name="ids">A collection of book IDs to delete.</param>
    /// <exception cref="KeyNotFoundException">
    /// Thrown if no books are found with the provided IDs.
    /// </exception>
    public async Task SoftDeleteRangeAsync(IEnumerable<int> ids)
    {
        var books = await _context.Books
            .Where(b => ids.Contains(b.Id) && !b.IsDeleted)
            .ToListAsync();

        if (!books.Any())
            throw new KeyNotFoundException("No books found with the provided IDs");

        foreach (var book in books)
        {
            book.IsDeleted = true;
        }

        await _context.SaveChangesAsync();
    }
}