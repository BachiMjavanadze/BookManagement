namespace BookManagement.Core.DTOs.BookDTOs;

public class BookDetailsDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int PublicationYear { get; set; }
    public string AuthorName { get; set; } = null!;
    public int ViewsCount { get; set; }
    public double PopularityScore { get; set; }
}
