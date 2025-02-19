using BookManagement.API.Models;
using BookManagement.Core.DTOs.BookDTOs;
using BookManagement.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BookManagement.API.Controllers;

[Produces("application/json")]
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    /// <summary>
    /// Retrieves all books, paginated by page and pageSize.
    /// </summary>
    /// <param name="page">The page number (default is 1)</param>
    /// <param name="pageSize">The number of books per page (default is 10)</param>
    /// <returns>A list of book titles</returns>
    /// <response code="200">Returns the list of book titles</response>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Retrieve a paginated list of books.",
        Description = "Returns a list of book titles, sorted from most popular to less popular."
    )]
    [ProducesResponseType(typeof(IEnumerable<BookTitleDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<IEnumerable<BookTitleDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var books = await _bookService.GetAllAsync(page, pageSize);
        return Ok(books);
    }


    /// <summary>
    /// Retrieves the details of a book with the given id.
    /// </summary>
    /// <param name="id">The id of the book</param>
    /// <returns>The book details</returns>
    /// <response code="200">Returns the book details</response>
    /// <response code="404">If the book is not found</response>
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Retrieve book details by ID.",
        Description = "Returns the full details of a book including title, publication year, author, views count, and popularity score."
    )]
    [ProducesResponseType(typeof(BookDetailsDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookDetailsDto>> GetDetailsById(int id)
    {
        var bookDetails = await _bookService.GetDetailsByIdAsync(id);
        return Ok(bookDetails);
    }

    /// <summary>
    /// Retrieves the details of books whose name contains the given term.
    /// </summary>
    /// <param name="term">The search term</param>
    /// <returns>A list of book details</returns>
    /// <response code="200">Returns the list of book details</response>
    [HttpGet("search")]
    [SwaggerOperation(
        Summary = "Search books by term.",
        Description = "Searches for books that contain the provided term in the title or the author name."
    )]
    [ProducesResponseType(typeof(IEnumerable<BookDetailsDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<BookDetailsDto>>> GetDetailsByName([FromQuery] string term)
    {
        var books = await _bookService.GetDetailsByNameAsync(term);
        return Ok(books);
    }

    /// <summary>
    /// Creates a new book.
    /// </summary>
    /// <param name="dto">The book create DTO</param>
    /// <returns>The created book</returns>
    /// <response code="201">Returns the created book</response>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new book.",
        Description = "Adds a new book to the system."
    )]
    [ProducesResponseType(typeof(BookDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status409Conflict)]
    public async Task<ActionResult<BookDto>> Create([FromBody] BookCreateDto dto)
    {
        var createdBook = await _bookService.AddAsync(dto);
        return CreatedAtAction(nameof(GetDetailsById), new { id = createdBook.Id }, createdBook);
    }

    /// <summary>
    /// Creates multiple books at once.
    /// </summary>
    /// <param name="dtos">The list of book create DTOs</param>
    /// <returns>No content</returns>
    /// <response code="204">No content</response>
    [HttpPost("bulk")]
    [SwaggerOperation(
        Summary = "Bulk create books.",
        Description = "Adds multiple books to the system in one request."
    )]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateBulk([FromBody] IEnumerable<BookCreateDto> dtos)
    {
        await _bookService.AddRangeAsync(dtos);
        return Ok();
    }

    /// <summary>
    /// Updates an existing book.
    /// </summary>
    /// <param name="id">The id of the book</param>
    /// <param name="dto">The book update DTO</param>
    /// <returns>The updated book</returns>
    /// <response code="200">Returns the updated book</response>
    /// <response code="404">If the book is not found</response>
    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update a book.",
        Description = "Updates the details of an existing book."
    )]
    [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status409Conflict)]
    public async Task<ActionResult<BookDto>> Update(int id, [FromBody] BookUpdateDto dto)
    {
        var updatedBook = await _bookService.UpdateAsync(id, dto);
        return Ok(updatedBook);
    }

    /// <summary>
    /// Soft deletes a single book.
    /// </summary>
    /// <param name="id">The id of the book</param>
    /// <returns>No content</returns>
    /// <response code="204">No content</response>
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a book.",
        Description = "Deletes the book from the system."
    )]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> SoftDelete(int id)
    {
        await _bookService.SoftDeleteAsync(id);
        return NoContent();
    }

    /// <summary>
    /// Soft deletes multiple books at once.
    /// </summary>
    /// <param name="ids">The list of book ids</param>
    /// <returns>No content</returns>
    /// <response code="204">No content</response>
    [HttpDelete("bulk")]
    [SwaggerOperation(
        Summary = "Bulk delete books.",
        Description = "Deletes multiple books from the system."
    )]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> SoftDeleteBulk([FromBody] IEnumerable<int> ids)
    {
        await _bookService.SoftDeleteRangeAsync(ids);
        return NoContent();
    }
}