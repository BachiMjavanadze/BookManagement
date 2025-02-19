using BookManagement.Core.Models;

namespace BookManagement.Infrastructure.Data.Seed;

public static class BookSeedData
{
    public static List<Book> GetSeedData()
    {
        return new List<Book>
        {
            new Book { Id = 1, Title = "The Great Gatsby", AuthorName = "F. Scott Fitzgerald", PublicationYear = 1925, ViewsCount = 150, IsDeleted = false },
            new Book { Id = 2, Title = "1984", AuthorName = "George Orwell", PublicationYear = 1949, ViewsCount = 200, IsDeleted = false },
            new Book { Id = 3, Title = "Pride and Prejudice", AuthorName = "Jane Austen", PublicationYear = 1813, ViewsCount = 180, IsDeleted = false },
            new Book { Id = 4, Title = "To Kill a Mockingbird", AuthorName = "Harper Lee", PublicationYear = 1960, ViewsCount = 170, IsDeleted = false },
            new Book { Id = 5, Title = "The Catcher in the Rye", AuthorName = "J.D. Salinger", PublicationYear = 1951, ViewsCount = 130, IsDeleted = false },
            new Book { Id = 6, Title = "One Hundred Years of Solitude", AuthorName = "Gabriel García Márquez", PublicationYear = 1967, ViewsCount = 140, IsDeleted = false },
            new Book { Id = 7, Title = "Brave New World", AuthorName = "Aldous Huxley", PublicationYear = 1932, ViewsCount = 160, IsDeleted = false },
            new Book { Id = 8, Title = "The Lord of the Rings", AuthorName = "J.R.R. Tolkien", PublicationYear = 1954, ViewsCount = 250, IsDeleted = false },
            new Book { Id = 9, Title = "Jane Eyre", AuthorName = "Charlotte Brontë", PublicationYear = 1847, ViewsCount = 120, IsDeleted = false },
            new Book { Id = 10, Title = "Crime and Punishment", AuthorName = "Fyodor Dostoevsky", PublicationYear = 1866, ViewsCount = 110, IsDeleted = false },
            new Book { Id = 11, Title = "The Hobbit", AuthorName = "J.R.R. Tolkien", PublicationYear = 1937, ViewsCount = 230, IsDeleted = false },
            new Book { Id = 12, Title = "Don Quixote", AuthorName = "Miguel de Cervantes", PublicationYear = 1605, ViewsCount = 90, IsDeleted = false },
            new Book { Id = 13, Title = "The Divine Comedy", AuthorName = "Dante Alighieri", PublicationYear = 1320, ViewsCount = 80, IsDeleted = false },
            new Book { Id = 14, Title = "The Brothers Karamazov", AuthorName = "Fyodor Dostoevsky", PublicationYear = 1880, ViewsCount = 100, IsDeleted = false },
            new Book { Id = 15, Title = "Wuthering Heights", AuthorName = "Emily Brontë", PublicationYear = 1847, ViewsCount = 140, IsDeleted = false },
            new Book { Id = 16, Title = "The Odyssey", AuthorName = "Homer", PublicationYear = -800, ViewsCount = 70, IsDeleted = false },
            new Book { Id = 17, Title = "The Picture of Dorian Gray", AuthorName = "Oscar Wilde", PublicationYear = 1890, ViewsCount = 160, IsDeleted = false },
            new Book { Id = 18, Title = "War and Peace", AuthorName = "Leo Tolstoy", PublicationYear = 1869, ViewsCount = 120, IsDeleted = false },
            new Book { Id = 19, Title = "The Count of Monte Cristo", AuthorName = "Alexandre Dumas", PublicationYear = 1844, ViewsCount = 150, IsDeleted = false },
            new Book { Id = 20, Title = "Anna Karenina", AuthorName = "Leo Tolstoy", PublicationYear = 1877, ViewsCount = 140, IsDeleted = false },
            new Book { Id = 21, Title = "Les Misérables", AuthorName = "Victor Hugo", PublicationYear = 1862, ViewsCount = 130, IsDeleted = false },
            new Book { Id = 22, Title = "The Iliad", AuthorName = "Homer", PublicationYear = -760, ViewsCount = 60, IsDeleted = false },
            new Book { Id = 23, Title = "Frankenstein", AuthorName = "Mary Shelley", PublicationYear = 1818, ViewsCount = 170, IsDeleted = false },
            new Book { Id = 24, Title = "The Canterbury Tales", AuthorName = "Geoffrey Chaucer", PublicationYear = 1392, ViewsCount = 50, IsDeleted = false },
            new Book { Id = 25, Title = "Moby-Dick", AuthorName = "Herman Melville", PublicationYear = 1851, ViewsCount = 140, IsDeleted = false },
            new Book { Id = 26, Title = "Oliver Twist", AuthorName = "Charles Dickens", PublicationYear = 1837, ViewsCount = 120, IsDeleted = false },
            new Book { Id = 27, Title = "Dracula", AuthorName = "Bram Stoker", PublicationYear = 1897, ViewsCount = 180, IsDeleted = false },
            new Book { Id = 28, Title = "The Three Musketeers", AuthorName = "Alexandre Dumas", PublicationYear = 1844, ViewsCount = 130, IsDeleted = false },
            new Book { Id = 29, Title = "Great Expectations", AuthorName = "Charles Dickens", PublicationYear = 1861, ViewsCount = 140, IsDeleted = false },
            new Book { Id = 30, Title = "The Adventures of Sherlock Holmes", AuthorName = "Arthur Conan Doyle", PublicationYear = 1892, ViewsCount = 190, IsDeleted = false }
        };
    }
}
