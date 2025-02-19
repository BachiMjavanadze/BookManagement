using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookManagement.Core.DTOs.BookDTOs;

namespace BookManagement.Core.Models;

public class Book
{
    public int Id { get; set; }

    [Required]
    [Length(1, 50, ErrorMessage = "The {0} length must be in the range of {1}-{2} characters")]
    [Column(TypeName = "nvarchar(50)")]
    public string Title { get; set; } = null!;

    [Required]
    public int PublicationYear { get; set; }

    [Required]
    [Length(1, 50, ErrorMessage = "The {0} length must be in the range of {1}-{2} characters")]
    [Column(TypeName = "nvarchar(50)")]
    public string AuthorName { get; set; } = null!;

    public int ViewsCount { get; set; } = 0;

    public bool IsDeleted { get; set; } = false;
}
