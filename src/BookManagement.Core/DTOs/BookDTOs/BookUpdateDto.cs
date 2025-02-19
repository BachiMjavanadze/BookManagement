using System.ComponentModel.DataAnnotations;

namespace BookManagement.Core.DTOs.BookDTOs;

public class BookUpdateDto
{
    [Required]
    [Length(1, 50, ErrorMessage = "The {0} length must be in the range of {1}-{2} characters")]
    public string Title { get; set; } = null!;

    [Required]
    public int PublicationYear { get; set; }

    [Required]
    [Length(1, 50, ErrorMessage = "The {0} length must be in the range of {1}-{2} characters")]
    public string AuthorName { get; set; } = null!;
}
