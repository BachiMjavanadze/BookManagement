namespace BookManagement.Core.Exceptions;

public class DuplicateTitleException : BadRequestException
{
    public DuplicateTitleException(string title)
        : base($"A book with the title '{title}' already exists.") { }
}
