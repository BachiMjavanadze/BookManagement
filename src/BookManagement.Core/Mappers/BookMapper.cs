using BookManagement.Core.DTOs.BookDTOs;
using BookManagement.Core.Models;

namespace BookManagement.Core.Mappers;

/// <summary>
/// Provides extension methods to map between <see cref="Book"/> domain models and various Book DTOs.
/// </summary>
public static class BookMapper
{
    public static Book ToBook(this BookCreateDto dto)
    {
        return new Book
        {
            Title = dto.Title,
            AuthorName = dto.AuthorName,
            PublicationYear = dto.PublicationYear
        };
    }

    public static Book ToBook(this BookUpdateDto dto, int id)
    {
        return new Book
        {
            Id = id,
            Title = dto.Title,
            AuthorName = dto.AuthorName,
            PublicationYear = dto.PublicationYear
        };
    }

    public static BookDto ToBookDto(this Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            PublicationYear = book.PublicationYear,
            AuthorName = book.AuthorName,
        };
    }

    public static BookTitleDto ToBookTitleDto(this Book book)
    {
        return new BookTitleDto
        {
            Id = book.Id,
            Title = book.Title,
        };
    }

    public static IEnumerable<BookTitleDto> ToBookTitleDtoList(this IEnumerable<Book> books)
    {
        return books.Select(b => b.ToBookTitleDto());
    }

    public static BookDetailsDto ToBookDetailsDto(this Book book)
    {
        var currentYear = DateTime.Now.Year;
        var yearsSincePublished = currentYear - book.PublicationYear;
        var popularityScore = book.ViewsCount * 0.5 + yearsSincePublished * 2;

        return new BookDetailsDto
        {
            Id = book.Id,
            Title = book.Title,
            PublicationYear = book.PublicationYear,
            AuthorName = book.AuthorName,
            ViewsCount = book.ViewsCount,
            PopularityScore = popularityScore
        };
    }

    public static IEnumerable<BookDetailsDto> ToBookDetailsDtoList(this IEnumerable<Book> books)
    {
        return books.Select(b => b.ToBookDetailsDto());
    }
}