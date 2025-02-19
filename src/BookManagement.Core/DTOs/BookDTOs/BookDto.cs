namespace BookManagement.Core.DTOs.BookDTOs;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int PublicationYear { get; set; }
    public string AuthorName { get; set; } = null!;
}
